import tkinter as tk
from tkinter import messagebox
import serial
import time
import threading



font = "GohuFont 11 Nerd Font"

#setup ports
ardPort = 'COM3'
baudrate =  9600
arduino = None

#function to connect to arduino and tempSensor
def connect():
    global arduino
    try:
        arduino = serial.Serial(ardPort, baudrate)
        time.sleep(2)
        lbConnection.config(text="Status: Connected", fg="green")
        messagebox.showinfo("Connection", "Connection Stablished")
        startReading() #starts a data read in a separate tread
    except serial.SerialException:
        messagebox.showerror("Error", "Couldn't connect to Arduino device. Check your ports")

#Function for disconnect from arduino
def disconnect():
    global arduino
    if arduino and arduino.is_open:
        arduino.close()
        lbConnection.config(text="Status: Not connected", fg="red")
        messagebox.showinfo("Connection", "Connection Terminated")
    else:
        messagebox.showwarning("Warning", "There is no active connection")

#function to send temp limit to arduino
def sendLimit():
    global arduino
    if arduino and arduino.is_open:
        try:
            limit = tbTempLim.get()
            if limit.isdigit():
                arduino.write(f"{limit}".encode())
                arduino.flush()
                messagebox.showinfo("Sent", f"Temperature limit ({limit} degrees) has been sent")
            else:
                messagebox.showerror("Error", "Enter a numeric value for the limit")
        except Exception as ex:
            messagebox.showerror("Error", f"Couldn't send the limit {ex}")
    else:
        messagebox.showwarning("Warning", "There is no active connection")

#Function to read data from arduino
def readFromArduino():
    global arduino
    while arduino and arduino.is_open:
        try:
            data = arduino.readline().decode().strip()
            if "Temp" in data:
                print(data)
                tempValue = data.split(":")[1].strip()
                lbTemp.config(text=f"{tempValue} degrees Celcius")
                time.sleep(1)
        except Exception as ex:
            print(f"Error while reading data: {ex}")
            break

#function for start reading on a separate thread
def startReading():
    thread = threading.Thread(target=readFromArduino)
    thread.daemon = True
    thread.start()

#Configuring GUI

window = tk.Tk()
window.title("Interface for temperature monitoring")
window.geometry("400x300")

#title tag
lbTitleTemp = tk.Label(window, text="Current temperature", font=(font, 12))
lbTitleTemp.pack(pady=10)

#Shwo temp tag
lbTemp = tk.Label(window, text="-- degrees C", font=(font, 24))
lbTemp.pack()

#tag for connection state 
lbConnection = tk.Label(window, text="Status: Not Connected", fg="red", font=(font, 12))
lbConnection.pack(pady=5)

#For entering temp limit
lbTempLimit = tk.Label(window, text="Temperature limit")
lbTempLimit.pack(pady=5)
tbTempLim = tk.Entry(window, width=10)
tbTempLim.pack(pady=5)

#Send temp button
btnSend = tk.Button(window, text="Send limit", command=sendLimit, font=(font, 12))
btnSend.pack()

#connect button
btnConnect = tk.Button(window, text="Connect", command=connect, font=(font, 12))
btnConnect.pack(pady=5)

btnDisconnect = tk.Button(window, text="Disconnect", command=disconnect, font=(font, 12))
btnDisconnect.pack(pady=5)

window.mainloop()
