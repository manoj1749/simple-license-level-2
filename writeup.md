# Simple License Level-2 Walkthrough

- This user will be given the appgui binary which is a .Net client which can be used to communicate to a server.
- The client when launched will ask the user to enter a license key. The client enters the license key and if the entered license key is correct we will get the flag or else we will be asked for a valid license key.

So the first order of business is to figure out the correct license file or circumvent the licensing mechanism.

# Cracking The License Key

- We are presented with a dotnet binary. If we load it up in dotpeek, we can see that it sends the uset input and recieves a response from the server which is kind of a basic functionality, and also "123456789" is being commented near the code of converting the user input to bytes, which says that there is some relation between "123456789" and license key.
- So when we try entering the "123456789" as license key we will be getting "Length of string is not as expected" as a response from the server, from which we can say that it checks the length of the input.
- Now bruteforcing strings of various lengths we will be finding that when a string of length 10 is entered we will be getting "Invalid License Key" as a response from the server.
- Such we found out the length of the required license key is 10.
- After spending some time figuring out the logic for the license key with the hints we found out, such when we go through the divisors of that number we will find many 5 digit numbers, arranging the any 2 of those 5 digit numbers and bruteforcing through it will be finding out the correct license key.
- The numbers "10821 and 11409" arranged as a number together like "1082111409" is the correct license key.

Then by entering the obtained license key and entering in the .Net client will provide us the flag
