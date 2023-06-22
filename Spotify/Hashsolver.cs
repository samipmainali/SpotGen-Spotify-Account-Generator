using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Spotgen.Spotify
{
    internal class Hashsolver
    {
        // Convert a byte array to a long value
        private static long fromByteArray(byte[] _1)
        {
            Array.Reverse(_1); // Reverse the byte array to match the endianness of BitConverter
            return BitConverter.ToInt64(_1, 0); // Convert the reversed byte array to a long value
        }

        // Create a copy of a range of bytes from an array
        private static byte[] copyOfRange(byte[] _1, int from, int to)
        {
            var numArray = new byte[to - from]; // Create a new byte array with the specified length
            var index1 = 0;
            for (var index2 = from; index2 < to; ++index2) // Iterate over the specified range of bytes
            {
                numArray[index1] = _1[index2]; // Copy each byte to the new array
                ++index1;
            }

            return numArray; // Return the copied byte array
        }

        // Compute the SHA-1 hash of a byte array
        private static byte[] sha12(byte[] str)
        {
            return new SHA1CryptoServiceProvider().ComputeHash(str); // Compute the SHA-1 hash of the input byte array
        }

        // Convert a long value to a byte array
        private static byte[] toByteArray(long a)
        {
            var numArray = new byte[8]; // Create a new byte array with a length of 8 (sizeof long)
            for (var index = 0; index < 8; ++index)
                numArray[index] = (byte)(((ulong)a >> (56 - 8 * index)) & byte.MaxValue);
            // Convert the long value to a byte array using bitwise operations and bit shifting
            // Each byte is extracted from the long value and stored in the byte array
            return numArray; // Return the byte array representation of the long value
        }

        // Concatenate two byte arrays
        private static byte[] concat(byte[] _1, byte[] _2)
        {
            var numArray = new byte[_1.Length + _2.Length]; // Create a new byte array with the combined length
            for (var index = 0; index < _1.Length; ++index)
                numArray[index] = _1[index]; // Copy the elements from the first byte array to the new array
            for (var index = 0; index < _2.Length; ++index)
                numArray[index + _1.Length] = _2[index]; // Copy the elements from the second byte array to the new array, after the first array
            return numArray; // Return the concatenated byte array
        }

        // Count the number of trailing zeros in a byte array
        private static int countTrailingZeros(byte[] array)
        {
            var num1 = 20; // Constant representing the length of the array (number of bytes)
            byte num2 = 1; // Initial value for a bitmask
            var index = num1 - 1; // Start from the last byte of the array
            var num3 = 0; // Counter for the number of trailing zeros
            int num4;
            byte num5;
            byte num6;
            int num7;
            while (true)
            {
                num4 = num3;
                if (index >= 0)
                {
                    num5 = array[index]; // Get the current byte from the array
                    num6 = num2; // Set the bitmask for checking trailing zeros
                    num7 = num3;
                    if (num5 <= 0) // If the byte is zero, all bits are zeros
                    {
                        num3 += 8; // Increment the counter by 8 (number of bits in a byte)
                        --index; // Move to the previous byte in the array
                    }
                    else
                    {
                        goto label_7; // If the byte is non-zero, go to the next step
                    }
                }
                else
                {
                    break; // Exit the loop when all bytes have been processed
                }
            }

            return num4; // Return the number of trailing zeros
        label_7:
            int num8;
            while (true)
            {
                num8 = num7;
                if (num6 != 0) // If the bitmask is not zero
                {
                    num8 = num7;
                    if ((num5 & (uint)num6) <= 0U) // Check if the corresponding bit is zero
                    {
                        ++num7; // Increment the counter for trailing zeros
                        num6 <<= 1; // Shift the bitmask to the left
                    }
                    else
                    {
                        break; // Exit the loop when a non-zero bit is found
                    }
                }
                else
                {
                    break; // Exit the loop when the bitmask becomes zero
                }
            }

            return num8; // Return the number of trailing zeros
        }

        // Find a suffix that produces a matching hash
        private static byte[] findSuffix(byte[] array, int n, long n2)
        {
            var byteArray = toByteArray(n2); // Convert the long value to a byte array
            long a = 0; // Counter for the suffix search
            var _2 = concat(byteArray, toByteArray(0L)); // Concatenate the byte array and a byte array representing zero
            var array1 = sha12(concat(array, _2)); // Compute the hash of the concatenated arrays
            while (countTrailingZeros(array1) < n) // Repeat until the hash has the required number of trailing zeros
            {
                _2 = concat(toByteArray(n2), toByteArray(a)); // Concatenate the byte array representing the long value and the byte array representing the counter
                array1 = sha12(concat(array, _2)); // Compute the hash of the concatenated arrays
                ++n2; // Increment the long value
                ++a; // Increment the counter
            }

            return _2; // Return the suffix byte array
        }

        // Decode the input by finding a suffix that produces a matching hash
        public static byte[] Decode(byte[] _1, byte[] _2, int _3)
        {
            var n2 = fromByteArray(copyOfRange(sha12(_1), 12, 20)); // Compute a long value from a range of bytes in the hash of _1
            return findSuffix(_2, _3, n2); // Find a suffix that produces a matching hash and return it
        }
    }
}
