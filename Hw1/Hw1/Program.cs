// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using Hw1;

while (true)
{
    Console.WriteLine("Please use zero numeration");
    Console.Write("Would you like to Encode[E] or Decode[D]: ");
    string answer = Console.ReadLine() ?? string.Empty;
    if (answer == "E")
    {
        Console.Write("Input (Example: ABCDEF): ");
        (string, int) output = BWT.Encode(Console.ReadLine() ?? string.Empty);
        Console.WriteLine("Encoded: " + output.Item1 + " " + output.Item2);
    }
    else if (answer == "D")
    {
        Console.Write("Input (Example: ABCDEF 3): ");
        string[] data = (Console.ReadLine() ?? string.Empty).Split().ToArray();
        if (data.Length > 1 && int.TryParse(data[1], out int position))
        {
            string encoded = data[0];
            string output = BWT.Decode(encoded, position);
            Console.WriteLine("Decoded: " + output);
        }
        else
        {
            Console.WriteLine("Wrong input");
        }
    }
    else
    {
        Console.WriteLine("Wrong input");
    }

    Console.WriteLine();
}