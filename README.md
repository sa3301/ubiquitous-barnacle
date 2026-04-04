# AZURE CLOUD MIGRATION

We start by creating a storage account in Azure:

<img width="1470" height="923" alt="Screenshot 2026-04-03 at 1 11 12 PM" src="https://github.com/user-attachments/assets/be55b8df-244d-4161-a241-0e0d5e945520" />

> blob service > create new container; we name it [backups]
<img width="1470" height="923" alt="image" src="https://github.com/user-attachments/assets/0d602491-086b-4259-870b-3af4a0f5ea86" />
i then opened codespace and wrote code to connect to azure this is availbale on the repo
<img width="1470" height="923" alt="Screenshot 2026-04-03 at 5 48 25 PM" src="https://github.com/user-attachments/assets/59446c93-a4a3-4c8e-9f05-0e1eb4198d97" />

i wrote code in C# (.NET) and got the connection key onto codespace but removed it for the commit for security reasons
<img width="1470" height="923" alt="Screenshot 2026-04-03 at 5 58 50 PM" src="https://github.com/user-attachments/assets/81401203-16a3-4aa7-913b-0a68f7bb7ee1" />
In the Program.cs code i added options for automated file upload, download, etc.
<img width="1470" height="923" alt="Screenshot 2026-04-03 at 6 12 32 PM" src="https://github.com/user-attachments/assets/843cc3f0-4434-465d-a05b-a946a28f1ce7" />
lets try uploading a file named test.txt
<img width="827" height="180" alt="Screenshot 2026-04-03 at 6 16 18 PM" src="https://github.com/user-attachments/assets/32d09c2e-f9ed-4c40-bd56-c5340e9987d3" />
we have successfully uploaded the file onto Azure
<img width="1470" height="923" alt="Screenshot 2026-04-03 at 6 19 14 PM" src="https://github.com/user-attachments/assets/90961002-cf18-4ebe-8585-b1ca4935ec18" />
BUT wait, what if the file could be corrupted? lets check the integrity of the file using SHA-256: (again, automation >>)
<img width="659" height="157" alt="Screenshot 2026-04-03 at 6 50 55 PM" src="https://github.com/user-attachments/assets/b7c297c4-5e6d-4f62-ac92-cd3aebbc0624" />

but im not satisfied there. lets try automation of bulk files. so i add 'bulk file automation code' to the program.cs framework. 
lets test it by creating another file test2.txt
<img width="336" height="115" alt="Screenshot 2026-04-03 at 6 58 11 PM" src="https://github.com/user-attachments/assets/afa3b416-c246-45e6-a581-96adc2ec805f" />

et voila!
<img width="1470" height="923" alt="Screenshot 2026-04-03 at 6 58 23 PM" src="https://github.com/user-attachments/assets/defaf94c-4daf-4058-b5cc-ab84e839031c" />







