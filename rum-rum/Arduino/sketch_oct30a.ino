#include <Servo.h>
#include <LiquidCrystal_I2C.h>
const int tempIn = A0;
const int servoPin =  3;
const int sda = A1;
const int scl = A0;
int initTempLimit  = 25;
int seriTempLimit  = -1;
int rawValue = 0;
double voltage = 0, tempC = 0, tempF = 0;

const int led1 = 8;
const int led2 = 9;


LiquidCrystal_I2C lcd(0x27,16,2);
Servo servo1;

void setup() {
  pinMode(led1,OUTPUT);
  pinMode(led2,OUTPUT);
  lcd.init();
  Serial.begin(9600);
  servo1.attach(servoPin);
  lcd.backlight();
  lcd.clear();
  digitalWrite(led1,HIGH);
}

void loop() {
  lcd.display();
  if (Serial.available() > 0)
  {
    seriTempLimit = Serial.parseInt();
    Serial.print("Temp recieved: ");
    Serial.println(seriTempLimit);
  }

    //READ
    rawValue = analogRead(tempIn);
    voltage = (rawValue / 1023.0) * 5000;
    tempC = voltage * 0.1;
    tempF = (tempC * 1.8) + 32;


    Serial.print("Temp:");
    Serial.println(tempC);
    lcd.setCursor(2, 0);
    lcd.print("Temperatura");
    lcd.setCursor(0, 1);
    lcd.print("Temp: ");
    lcd.print(tempC);

    int currentLimit = (seriTempLimit != -1) ? seriTempLimit : initTempLimit;

    if (tempC > currentLimit)
    {
      digitalWrite(led1,LOW);
      digitalWrite(led2,HIGH);
      servo1.write(0);
      delay(1000);
      servo1.write(90);
      delay(1000);
      servo1.write(180);
      delay(1000);
    }
    else
    {
      digitalWrite(led1,HIGH);
      digitalWrite(led2,LOW);
      servo1.write(90);
    }
    delay(500);
}
