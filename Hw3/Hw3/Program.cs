// Copyright (c) Murat Khamatyanov. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Hw3;

if (args.Length != 2)
{
    throw new ArgumentException($"Wrong input.");
}

if (args[1] == "-c")
{
    LZW.Compress(args[0]);
}
else if (args[1] == "-u")
{
    LZW.Decompress(args[0]);
}
else
{
    throw new ArgumentException($"Unknown key '{args[1]}'.");
}
