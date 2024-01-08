using System;
using System.Collections.Generic;

namespace FunctionalCodingPlayground {
    class Program {
        static void Main(string[] args) {
            // Currying example
            // Currying is a technique where a function with multiple arguments is transformed into a sequence of functions,
            // each taking a single argument.
            // This allows for partial application of arguments and the creation of new functions.
            // In this example, a curried function 'add' is defined that takes an integer 'x' and returns a function that takes
            // another integer 'y' and returns the sum of 'x' and 'y'.
            Func<int, Func<int, int>> add = x => y => x + y;
            var add5 = add(5);
            Console.WriteLine(add5(3)); // Output: 8
            // The 'add5' function is created by partially applying the 'add' function with '5'.
            // When 'add5' is called with '3', it adds '5' and '3' together, resulting in the output '8'.

            // Memoization example using a cache dictionary
            // Memoization is a technique used to cache the results of a function based on its inputs. This can significantly
            // improve the performance of a function by avoiding redundant computations.
            // In this example, a recursive function 'fibonacci' is defined that calculates the Fibonacci sequence.
            // A cache dictionary is used to store previously computed values, so that if the same input is encountered again,
            // the result can be retrieved from the cache instead of recomputing it.
            Func<int, int> fibonacci = null;
            fibonacci = n => {
                var cache = new Dictionary<int, int>();
                if (cache.ContainsKey(n))
                    return cache[n];
                else if (n < 2)
                    return n;
                else {
                    var result = fibonacci(n - 1) + fibonacci(n - 2);
                    cache[n] = result;
                    return result;
                }
            };
            Console.WriteLine(fibonacci(10)); // Output: 55
            // When 'fibonacci(10)' is called, it calculates the 10th number in the Fibonacci sequence.
            // The function uses memoization, storing the results of intermediate calculations in the cache dictionary.
            // If the function is called again with the same input, the result is retrieved from the cache instead of recomputing it.
            // This improves performance by avoiding redundant computations.

            // Naybe Monad example
            // Monads are a design pattern in functional programming that provide a structured way to handle computations with side effects.
            // Monads allow for chaining operations together in a sequential manner while managing the effects of each operation.
            // In this example, a function 'Divide' is defined that performs division and returns a 'double?' (nullable double) to
            // indicate the possibility of failure (e.g., division by zero).
            double? Divide(double x, double y) {
                if (y == 0)
                    return null;
                else
                    return x / y;
            }

            // The 'Calculate' function uses the Maybe monad pattern to chain division operations together and handle potential errors.
            // It uses the 'Divide' function to divide 10 by 'x', and if the result is not null, it divides 20 by the result.
            double? Calculate(double x) {
                var y = Divide(10, x);
                if (y.HasValue) {
                    var z = Divide(20, y.Value);
                    return z;
                } else {
                    return null;
                }
            }

            var result = Calculate(2);
            if (result.HasValue)
                Console.WriteLine($"Result: {result.Value}");
            else
                Console.WriteLine("Error: Division by zero");
            // The 'Calculate' function is called with the argument '2'. It first divides 10 by 'x' to obtain 'y'.
            // If 'y' is not null, it proceeds to divide 20 by 'y' to obtain 'z'.
            // The final result is stored in the 'result' variable.
            // If the result has a value, it is printed as the output.
            // If 'y' is null, indicating division by zero, an error message is printed.

            // Overall, this example demonstrates the usage of functional programming techniques in a console application.
            // Currying allows for the creation of functions with partially applied arguments, enabling code reuse.
            // Memoization improves performance by caching the results of expensive computations.
            // The Maybe monad pattern helps handle potential errors in a structured manner, ensuring proper computation flow.

        }
    }
}