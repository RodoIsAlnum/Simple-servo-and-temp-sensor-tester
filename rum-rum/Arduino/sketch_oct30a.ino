#include <Servo.h>

const int analogIn = A0;
const int servoPin =  9;
int initTempLimit  = 25;
int seriTempLimit  = -1;

int rawValue = 0;
double voltage = 0, tempC = 0, tempF = 0;
Servo servo1;

void setup() {
  Serial.begin(9600);
  servo1.attach(servoPin);
}

void loop() {
  if (Serial.available() > 0)
  {
    seriTempLimit = Serial.parseInt();
    Serial.print("Temp recieved: ");
    Serial.println(seriTempLimit);
  }

    //READ
    rawValue = analogRead(analogIn);
    voltage = (rawValue / 1023.0) * 5000;
    tempC = voltage * 0.1;
    tempF = (tempC * 1.8) + 32;

    Serial.print("Temp:");
    Serial.println(tempC);

    int currentLimit = (seriTempLimit != -1) ? seriTempLimit : initTempLimit;

    if (tempC > currentLimit)
    {
      servo1.write(0);
      delay(1000);
      servo1.write(90);
      delay(1000);
      servo1.write(180);
      delay(1000);
    }
    else
    {
      servo1.write(90);
    }
    delay(500);
}
