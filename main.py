import tkinter as tk
from akun import AkunPUBG

# List akun
data_akun = []

def tambah_akun():
    username = entry_username.get()
    level = entry_level.get()
    harga = entry_harga.get()
    detail = entry_detail.get()
    akun = AkunPUBG(username, level, harga, detail)
    data_akun.append(akun)
    tampilkan_akun()
    clear_entry()

def tampilkan_akun():
    listbox.delete(0, tk.END)
    for akun in data_akun:
        listbox.insert(tk.END, f"{akun.username} - Level {akun.level} - Rp{akun.harga}")

def clear_entry():
    entry_username.delete(0, tk.END)
    entry_level.delete(0, tk.END)
    entry_harga.delete(0, tk.END)
    entry_detail.delete(0, tk.END)

root = tk.Tk()
root.title("Jual Beli Akun PUBG")

# Input
tk.Label(root, text="Username").grid(row=0, column=0)
entry_username = tk.Entry(root)
entry_username.grid(row=0, column=1)

tk.Label(root, text="Level").grid(row=1, column=0)
entry_level = tk.Entry(root)
entry_level.grid(row=1, column=1)

tk.Label(root, text="Harga").grid(row=2, column=0)
entry_harga = tk.Entry(root)
entry_harga.grid(row=2, column=1)

tk.Label(root, text="Detail").grid(row=3, column=0)
entry_detail = tk.Entry(root)
entry_detail.grid(row=3, column=1)

tk.Button(root, text="Tambah Akun", command=tambah_akun).grid(row=4, column=0, columnspan=2)

# List akun
listbox = tk.Listbox(root, width=50)
listbox.grid(row=5, column=0, columnspan=2)

root.mainloop()