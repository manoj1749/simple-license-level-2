# Simple License Writeup

We are presented with a dotnet binary. If we load it up in dotpeek, we can see that its unobfuscated and the license check algorithm itself is a fairly 
simple SHA256 hash comparison. The flag is also present as plain text within the code, so we can just take and submit the same to score points.