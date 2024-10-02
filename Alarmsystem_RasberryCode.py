
# -*- coding: utf-8 -*-
from gpiozero import LED, Button as GpioButton
from time import sleep
from tkinter import *
import threading
from flask import Flask, request, jsonify
import requests

app = Flask(__name__)
dotnet_backend_ip = "10.1.10.125"
dotnet_backend_port = "5001"  # Assurez-vous que ce port est correct et ouvert pour les requêtes

# Assurez-vous que le port est correct
endpoint = f"http://{dotnet_backend_ip}:{dotnet_backend_port}/api/zones/receive_zones_data"
headers = {
    'Content-Type': 'application/json'
}

class SystemAlarm:
    systemStatus = 0
    EtatZone1 = "OFF"
    EtatZone2 = "OFF"
    EtatZone3 = "OFF"
    EtatZone4 = "OFF"

    def __init__(self, root):
        self.sega = LED(18)
        self.segb = LED(9)
        self.segc = LED(10)
        self.segd = LED(11)
        self.sege = LED(12)
        self.segf = LED(13)
        self.segg = LED(17)
        self.segdp = LED(20)
        self.lamp = LED(16)
        self.btn1 = GpioButton(27)
        self.btn2 = GpioButton(22)
        self.btn3 = GpioButton(5)
        self.btn4 = GpioButton(6)
        self.btn5 = GpioButton(19)

        self.tk = root
        self.lbltitle = Label(self.tk, text="Alarms")
        self.lbltitle.grid(row=0, column=0, columnspan=2)
        self.lblzone1 = Label(self.tk, text="Z1", background="white")
        self.lblzone1.grid(row=1, column=0)
        self.lblzone2 = Label(self.tk, text="Z2", background="white")
        self.lblzone2.grid(row=1, column=1)
        self.lblzone3 = Label(self.tk, text="Z3", background="white")
        self.lblzone3.grid(row=2, column=0)
        self.lblzone4 = Label(self.tk, text="Z4", background="white")
        self.lblzone4.grid(row=2, column=1)
        self.lblStatus = Label(self.tk, text="Status")
        self.lblStatus.grid(row=3, column=0, columnspan=2)
        self.lbloN = Label(self.tk, text="ON", background="white")
        self.lbloN.grid(row=4, column=0)
        self.lbloFF = Label(self.tk, text="OFF", background="white")
        self.lbloFF.grid(row=4, column=1)
        self.btnAct = Button(self.tk, text="Activate", command=lambda: self.activate())
        self.btnAct.grid(row=5, column=0)
        self.btnDes = Button(self.tk, text="DeActivate", command=lambda: self.deactivate())
        self.btnDes.grid(row=5, column=1)
        self.btnRes = Button(self.tk, text="Reset", command=lambda: self.Reset())
        self.btnRes.grid(row=6, column=0, columnspan=2)

        self.show0()
        self.btn1.when_pressed = lambda: self.activate() if self.systemStatus == 0 else self.deactivate()
        self.btn2.when_pressed = lambda: self.Z1() if self.systemStatus == 1 else None
        self.btn3.when_pressed = lambda: self.Z2() if self.systemStatus == 1 else None
        self.btn4.when_pressed = lambda: self.Z3() if self.systemStatus == 1 else None
        self.btn5.when_pressed = lambda: self.Z4() if self.systemStatus == 1 else None

    def activate(self):
        self.lbloN.config(background="red")
        self.lbloFF.config(background="white")
        if self.systemStatus == 0:
            self.cout_up()
            thread2 = threading.Thread(target=self.cliniot)
            thread2.start()

    def deactivate(self):
        self.lbloFF.config(background="red")
        self.lbloN.config(background="white")
        self.lblzone1.config(background="white")
        self.lblzone2.config(background="white")
        self.lblzone3.config(background="white")
        self.lblzone4.config(background="white")
        self.EtatZone1 = "OFF"
        self.EtatZone2 = "OFF"
        self.EtatZone3 = "OFF"
        self.EtatZone4 = "OFF"
        if self.systemStatus == 1:
            self.cout_down()

    def show0(self):
        self.sega.off()
        self.segb.off()
        self.segc.off()
        self.segd.off()
        self.sege.off()
        self.segf.off()
        self.segg.on()
        self.segdp.on()

    def show1(self):
        self.sega.on()
        self.segb.off()
        self.segc.off()
        self.segd.on()
        self.sege.on()
        self.segf.on()
        self.segg.on()
        self.segdp.on()

    def show2(self):
        self.sega.off()
        self.segb.off()
        self.segc.on()
        self.segd.off()
        self.sege.off()
        self.segf.on()
        self.segg.off()
        self.segdp.on()

    def show3(self):
        self.sega.off()
        self.segb.off()
        self.segc.off()
        self.segd.off()
        self.sege.on()
        self.segf.on()
        self.segg.off()
        self.segdp.on()

    def show4(self):
        self.sega.on()
        self.segb.off()
        self.segc.off()
        self.segd.on()
        self.sege.on()
        self.segf.off()
        self.segg.off()
        self.segdp.on()

    def show5(self):
        self.sega.off()
        self.segb.on()
        self.segc.off()
        self.segd.off()
        self.sege.on()
        self.segf.off()
        self.segg.off()
        self.segdp.on()

    def show6(self):
        self.sega.off()
        self.segb.on()
        self.segc.off()
        self.segd.off()
        self.sege.off()
        self.segf.off()
        self.segg.off()
        self.segdp.on()

    def show7(self):
        self.sega.off()
        self.segb.off()
        self.segc.off()
        self.segd.on()
        self.sege.on()
        self.segf.on()
        self.segg.on()
        self.segdp.on()

    def show8(self):
        self.sega.off()
        self.segb.off()
        self.segc.off()
        self.segd.off()
        self.sege.off()
        self.segf.off()
        self.segg.off()
        self.segdp.on()

    def show9(self):
        self.sega.off()
        self.segb.off()
        self.segc.off()
        self.segd.on()
        self.sege.on()
        self.segf.off()
        self.segg.off()
        self.segdp.on()

    def showA(self):
        self.sega.off()
        self.segb.off()
        self.segc.off()
        self.segd.on()
        self.sege.off()
        self.segf.off()
        self.segg.off()

    def lampON(self):
        self.lamp.off()

    def lampOFF(self):
        self.lamp.on()

    def showpoint(self):
        self.segdp.off()

    def showNopoint(self):
        self.segdp.on()

    def cliniot(self):
        def cliniot_thread():
            while self.systemStatus == 1:
                self.showpoint()
                sleep(0.5)
                self.showNopoint()
                sleep(0.5)

        thread = threading.Thread(target=cliniot_thread)
        thread.start()

    def cout_up(self):
        self.show0()
        sleep(1)
        self.show1()
        sleep(1)
        self.show2()
        sleep(1)
        self.show3()
        sleep(1)
        self.show4()
        sleep(1)
        self.show5()
        sleep(1)
        self.show6()
        sleep(1)
        self.show7()
        sleep(1)
        self.show8()
        sleep(1)
        self.show9()
        sleep(1)
        self.showA()
        self.systemStatus = 1

    def cout_down(self):
        self.show9
        sleep(1)
        self.show8()
        sleep(1)
        self.show7()
        sleep(1)
        self.show6()
        sleep(1)
        self.show5()
        sleep(1)
        self.show4()
        sleep(1)
        self.show3()
        sleep(1)
        self.show2()
        sleep(1)
        self.show1()
        sleep(1)
        self.show0()
        sleep(1)
        self.show0()
        self.systemStatus = 0

    def Reset(self):
        self.systemStatus = 0
        self.lbloFF.config(background="white")
        self.lbloN.config(background="white")
        self.lblzone1.config(background="white")
        self.lblzone2.config(background="white")
        self.lblzone3.config(background="white")
        self.lblzone4.config(background="white")
        self.EtatZone1 = "OFF"
        self.EtatZone2 = "OFF"
        self.EtatZone3 = "OFF"
        self.EtatZone4 = "OFF"
        self.showA()

    def Z1(self):
        self.lblzone1.config(background="red")
        self.lblzone2.config(background="white")
        self.lblzone3.config(background="white")
        self.lblzone4.config(background="white")
        self.show1()
        self.EtatZone1 = "ON"
        self.EtatZone2 = "OFF"
        self.EtatZone3 = "OFF"
        self.EtatZone4 = "OFF"
        self.send_data("1", self.EtatZone1, self.EtatZone2, self.EtatZone3, self.EtatZone4)
        self.notify_frontend("Zone1", self.EtatZone1)

    def Z2(self):
        self.lblzone1.config(background="white")
        self.lblzone2.config(background="red")
        self.lblzone3.config(background="white")
        self.lblzone4.config(background="white")
        self.show2()
        self.EtatZone2 = "ON"
        self.EtatZone1 = "OFF"
        self.EtatZone3 = "OFF"
        self.EtatZone4 = "OFF"
        self.send_data("1", self.EtatZone1, self.EtatZone2, self.EtatZone3, self.EtatZone4)
        self.notify_frontend("Zone2", self.EtatZone2)

    def Z3(self):
        self.lblzone1.config(background="white")
        self.lblzone2.config(background="white")
        self.lblzone3.config(background="red")
        self.lblzone4.config(background="white")
        self.show3()
        self.EtatZone3 = "ON"
        self.EtatZone2 = "OFF"
        self.EtatZone1 = "OFF"
        self.EtatZone4 = "OFF"
        self.send_data("1", self.EtatZone1, self.EtatZone2, self.EtatZone3, self.EtatZone4)
        self.notify_frontend("Zone3", self.EtatZone3)

    def Z4(self):
        self.lblzone1.config(background="white")
        self.lblzone2.config(background="white")
        self.lblzone3.config(background="white")
        self.lblzone4.config(background="red")
        self.show4()
        self.EtatZone4 = "ON"
        self.EtatZone2 = "OFF"
        self.EtatZone3 = "OFF"
        self.EtatZone1 = "OFF"
        self.send_data("1", self.EtatZone1, self.EtatZone2, self.EtatZone3, self.EtatZone4)
        self.notify_frontend("Zone4", self.EtatZone4)

    def send_data(self, Id, Zone1, Zone2, Zone3, Zone4):
        zones_data = {
            "Id": Id,
            "Zone1": Zone1,
            "Zone2": Zone2,
            "Zone3": Zone3,
            "Zone4": Zone4
        }

        try:
            response = requests.post(endpoint, json=zones_data, headers=headers)
            response.raise_for_status()
            print("Données envoyées avec succès à la machine.")
        except requests.exceptions.RequestException as e:
            print(f"Erreur lors de l'envoi des données à la machine : {e}")

    def notify_frontend(self, zone, state):
        try:
            data = {
                "zone": zone,
                "state": state
            }
            response = requests.post(endpoint, json=data, headers=headers)
            response.raise_for_status()
        except requests.exceptions.RequestException as e:
            print(f"Erreur lors de l'envoi de la notification au frontend : {e}")

# Définir l'objet SystemAlarm au niveau global
sys = None

# Créer un événement pour synchroniser l'initialisation
initialization_event = threading.Event()

def start_tkinter_app():
    global sys
    root = Tk()
    sys = SystemAlarm(root)
    initialization_event.set()  # Indiquer que l'initialisation est terminée
    root.mainloop()

def start_flask_app():
    @app.route('/api/method/activate', methods=['POST'])
    def activate():
        global sys
        if sys:
            sys.activate()
            return jsonify({"status": "activated"}), 200
        else:
            return jsonify({"error": "System not initialized"}), 500

    @app.route('/api/method/deactivate', methods=['POST'])
    def deactivate():
        global sys
        if sys:
            sys.deactivate()
            return jsonify({"status": "deactivated"}), 200
        else:
            return jsonify({"error": "System not initialized"}), 500

    @app.route('/api/method/reset', methods=['POST'])
    def reset():
        global sys
        if sys:
            sys.Reset()
            return jsonify({"status": "reset"}), 200
        else:
            return jsonify({"error": "System not initialized"}), 500

    @app.route('/api/status', methods=['GET'])
    def api_status():
        global sys
        if sys:
            return jsonify({
                'systemStatus': sys.systemStatus,
                'EtatZone1': sys.EtatZone1,
                'EtatZone2': sys.EtatZone2,
                'EtatZone3': sys.EtatZone3,
                'EtatZone4': sys.EtatZone4
            }), 200
        else:
            return jsonify({"error": "System not initialized"}), 500

    @app.route('/api/zone_update', methods=['POST'])
    def zone_update():
        global sys
        data = request.json
        zone = data.get("zone")
        state = data.get("state")
        
        if sys:
            if zone == "Zone1":
                sys.EtatZone1 = state
            elif zone == "Zone2":
                sys.EtatZone2 = state
            elif zone == "Zone3":
                sys.EtatZone3 = state
            elif zone == "Zone4":
                sys.EtatZone4 = state
            return jsonify({"status": "updated"}), 200
        else:
            return jsonify({"error": "System not initialized"}), 500

    initialization_event.wait()  # Attendre que l'initialisation soit terminée
    app.run(host='0.0.0.0', port=5000)

if __name__ == "__main__":
    # Démarrer les threads Flask et Tkinter
    threading.Thread(target=start_flask_app).start()
    threading.Thread(target=start_tkinter_app).start()
