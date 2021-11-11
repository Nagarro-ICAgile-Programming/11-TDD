﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpCore
{


    
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrWhiteSpace(numbers))
            {
                return 0;
            }

            var separators = new List<char> { ',', '\n' };

            if (numbers.StartsWith("//"))
            {
                var customSeparator = numbers[2];

                if (customSeparator == '\n' || int.TryParse(customSeparator.ToString(), out _))
                {
                    throw new ArgumentException("Invalid");
                }
                
                separators.Add(customSeparator);
                numbers = numbers[numbers.IndexOf('\n')..];
            }
            
            return numbers
                .Split(separators.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                .Where(number => !string.IsNullOrWhiteSpace(number))
                .Select(numberString => int.TryParse(numberString.Trim(), out var result) ? result : throw new ArgumentException("Invalid"))
                .Sum();
        }
    }
}