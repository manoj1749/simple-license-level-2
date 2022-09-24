# Simple License Level-2 Walkthrough

This user will be given the appgui binary which is a .Net client which can be used to communicate to a server.
The client when launched will ask the user to enter a license key. The client enters the license key and if the entered license key is correct we will get the flag or else we will be asked for a valid license key.

So the first order of business is to figure out the correct license file or circumvent the licensing mechanism.

# Cracking The License Key

We are presented with a dotnet binary. If we load it up in dotpeek, we can see that it checks whether the length of the license key which the user provided is 10 or not, from this we got one clue that the length of license key is 10, and also "123456789" is being commented near the code of converting the user input to bytes, which says that there is some relation between "123456789" and license key.
So when we go through the divisors of that number we will find many 5 digit numbers, arranging the least 2-5 digit factors, "10821 and 11409" as a number together like "1082111409" is the correct license key.

Then by entering the obtained license key and entering in the .Net client will provide us the flag
