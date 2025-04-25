// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>
using Hw3;

string path;
int length;

while (true)
{
    Console.Write("Enter path and key (-c or -u) (for example: path/path/path.txt -c): ");
    path = Console.ReadLine()!;
    length = path.Length;
    if (length > 0 && path[(length - 2)..length] == "-c")
    {
        Console.WriteLine("Compression efficency: " + LZW.Compress(path[0..(length - 2)]));
    }
    else if (length > 0 && path[(length - 2)..length] == "-u")
    {
        LZW.DeCompress(path[0..(length - 2)]);
    }
    else
    {
        Console.WriteLine("Wrong input");
    }
}