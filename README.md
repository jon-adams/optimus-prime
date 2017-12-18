# optimus-prime

A little prime number factoring app.

## Installation

Windows installation with .Net 4.5.1 or newer is required.

The standard .Net 4.5.1 development tools may also be required to run the coverage and tests yourself. 

* Clone or otherwise acquire the repository

## Usage

* Run the pre-compiled `dist/Optimus.Prime.exe` passing in the following arguments:
  * the first number for the inclusive range for a prime number check 
  * the second number for the inclusive range for a prime number check
  * "alternate", "a", or "eratosthenes" for a third parameter to use the alternate [Sieve of Eratosthenes](https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes) algorithm
  * or for fun, instead use "race" as the third argument to see which algorithm is faster for different max prime values—the race does not output the entire prime list it generates since this mode is more about the timing comparison than the results

Example:

`"dist\Optimus.Prime.exe" 1 21234`
or
`"dist\Optimus.Prime.exe" 7900 7920 alternate`
or
`"dist\Optimus.Prime.exe" 1 30000000 race`
 

### Unit tests and Coverage report

To run the tests and the code coverage report over them:

* Build the solution in Visual Studio (or any .Net console build tool)
* Compile the project in Debug mode
* Run `cover.bat`   

## Requirements

* implement a prime number generator
* must return an ordered list of all prime numbers in a given range (inclusive of the endpoints)
* implement the supplied `PrimeNumberGenerator` interface
* deliverable must be a small main program to drive the generator
  * must allow the user to specify the prime number range via the command line
* all unit tests must pass, as well as provide 100% code coverage
* handle inverse ranges such that 1-10 and 10-1 are equivalent
* ensure that there is a test against the range 7900 and 7920

## Development Plan

* ✓ yeoman template
* ✓ update libraries but stick to default .Net framework level for the ease of the consumer
* ✓ setup coverage tool and script to run it
* ✓ TDD test setup
* ✓ implement [basic/brute force prime number](https://en.wikipedia.org/wiki/Primality_test)
* ✓ throw in faster Sieve of Eratosthenes implementation
* for fun, maybe throw in some parallelization so it uses more than one CPU core?