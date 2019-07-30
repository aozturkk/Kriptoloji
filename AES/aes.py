import os
from cryptography.hazmat.primitives.ciphers import Cipher, algorithms, modes
from cryptography.hazmat.backends import default_backend
import base64
import hashlib


def encrypt(plain_text,key,iv):

	plain_text = base64.b64encode(plain_text.encode()).decode()
	backend = default_backend()
	cipher = Cipher(algorithms.AES(key), modes.CBC(iv), backend=backend)
	encryptor = cipher.encryptor()
	plain_text_byte = pad(plain_text).encode()
	buf = bytearray( 2*len(plain_text_byte) - 1  )
	len_encrypted = encryptor.update_into(plain_text_byte, buf)
	ct = bytes(buf[:len_encrypted]) + encryptor.finalize()	
	return base64.b64encode(ct).decode()
	
def decrypt(encrypt_text,key,iv):

	backend = default_backend()
	cipher = Cipher(algorithms.AES(key), modes.CBC(iv), backend=backend)
	decryptor = cipher.decryptor()
	base64_decoded = base64.b64decode(encrypt_text)
	buf = bytearray( 2*len(base64_decoded) - 1  )
	len_decrypted = decryptor.update_into(base64_decoded, buf)
	dec = bytes(buf[:len_decrypted]) + decryptor.finalize()
	dec = unpad(dec).decode()
	return base64.b64decode(dec).decode()
	
def pad(s):
    return s + (32 - len(s) % 32) * chr(32 - len(s) % 32)	

def unpad(s):
	return s[:-ord(s[len(s)-1:])]	

print("1- Encrypt \n2- Decrypt \nSelect Option :")	
option = input()	
print("Text :")
text = input()
print("Key :")
key = input()	


key = hashlib.md5( hashlib.sha256( (key).encode() ).hexdigest().encode() ).hexdigest().encode()
iv = '4377777172699a75'.encode()

if option == '1':
	enc = encrypt(text,key,iv)
	print("Encrypt :",enc)
else :
	dec = decrypt(text,key,iv)	
	print("Decrypt :",dec)