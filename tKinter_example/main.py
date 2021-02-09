def ayrintigoster(listbox, sehirler):
    cs = listbox.curselection()
    for i in sehirler:
        if(i[1] == listbox.get(cs)):
            entCity.delete(0,"end")
            entCity.insert(0, i[0])
            entMeshur.delete(0,"end")
            entMeshur.insert(0, i[3])
            entBolge.delete(0,"end")
            entBolge.insert(0, i[2])
            entPlaka.delete(0,"end")
            entPlaka.insert(0, i[4])

from tkinter import *
import pickle
window = Tk()
window.title("TURKIYE-SEHIRLER")
window.geometry("400x200")
Label(window, text="Kisatlamalar")
yscroll = Scrollbar(window, orient=VERTICAL)
yscroll.grid(row=0, column=1, rowspan=7, sticky=NS)
listbox = Listbox(window, height=10, width=10, yscrollcommand=yscroll.set)
listbox.grid(row=0, column=0, rowspan=7, sticky=NSEW)

f = open("untitled.txt","r")
sehirler = []
for i in f:
    i = i.split(",")
    i[4] = i[4].strip("\n")
    sehirler.append(i)

kisaltmalar = []
for i in sehirler:
    kisaltmalar.append(i[1])
    listbox.insert(END, i[1])


yscroll["command"] = listbox.yview
Label(window, text="Sehir Adi:").grid(row=0, column=3, padx=4, sticky=E)
Label(window, text="Nesi Meshur:").grid(row=1, column=3, padx=4, sticky=E)
Label(window, text="Bolgesi: ").grid(row=2, column=3,padx=4,sticky=E)
Label(window, text="Plaka Kodu:").grid(row=3, column=3,padx=4,sticky=E)
entCity = Entry(window, width=15)
entCity.grid(row=0, column=4, sticky=W)
entMeshur = Entry(window, width=15)
entMeshur.grid(row=1, column=4,)
entBolge = Entry(window, width=15)
entBolge.grid(row=2, column=4)
entPlaka = Entry(window, width=15)
entPlaka.grid(row=3, column=4)

listbox.bind('<Double-1>', lambda x: ayrintigoster(listbox, sehirler))


window.mainloop()