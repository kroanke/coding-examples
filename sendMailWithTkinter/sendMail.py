# Python code to send mail from your
# gmail account with GUI
import smtplib
from tkinter import *
from tkinter import messagebox


root = Tk()

root.title("Send Email")

root.geometry("400x350")


def sendMail():
    # creates SMTP session
    try:
        smtpserver = smtplib.SMTP('smtp.gmail.com', 587)
        smtpserver.ehlo()
        smtpserver.starttls()
        smtpserver.ehlo()
        # gmail name, password
        smtpserver.login(entrySource.get(), entryPass.get())
        message = entryText.get(1.0, "end-1c")
        # Try to send message from a gmail account to an e-mail account.

        smtpserver.sendmail(entrySource.get(), entryDest.get(), message)
        messagebox.showinfo("Information","Mail Successfully sent!!")
        print("Mail successfully sent.")
    except:
        messagebox.showwarning("Warning", "An error occured\n"
                               "Couldnt Send the Mail")
        print("An error occured")

    # terminating the session
    smtpserver.quit()


sourceEmail = Label(root, text = "Your Email")
sourceEmail.grid(row=0,column =0)
sourceEmail.pack()

entrySource = Entry(root)
entrySource.insert(0, 'example@gmail.com')
entrySource.pack()

sourcePass = Label(root, text = "Password")
sourcePass.pack()
entryPass = Entry(root, show='*')
entryPass.pack()


destEmail = Label(root, text = "Destination Email")
destEmail.pack()
entryDest = Entry(root)
entryDest.insert(0, 'example@anymail.com')
entryDest.pack()


text = Label(root, text = "Text")
text.pack()
entryText = Text(root,relief=GROOVE, height=5, width=50,borderwidth=2)
entryText.pack()



button = Button(root, text="Send", command=sendMail,width = 30, borderwidth =2)
button.pack()
root.mainloop()
