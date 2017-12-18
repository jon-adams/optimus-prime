# optimus-prime

A little prime number factoring app.

## Installation

Windows installation with .Net 4.5.1 or newer is required.

The standard .Net 4.5.1 development tools may also be required to run the coverage and tests yourself. 

* Clone or otherwise acquire the repository

## Usage

* Build the solution in Visual Studio (or any .Net console build tool)
* Run the resulting `Optimus.Prime.exe` passing in the following arguments:
  * the first number for the inclusive range for a prime number check 
  * the second number for the inclusive range for a prime number check
  * "alternate", "a", or "eratosthenes" for a third parameter to use the alternate "Sieve of Eratosthenes" algorithm

Example:

`"optimus prime\bin\Debug\Optimus.Prime.exe" 1 21234`
or
`"optimus prime\bin\Debug\Optimus.Prime.exe" 7900 7920 alternate`
 

### Unit tests and Coverage report

To run the tests and the code coverage report over them:

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

## Plan

* ✓ yeoman template
* ✓ update libraries but stick to default .Net framework level for the ease of the consumer
* ✓ setup coverage tool and script to run it
* ✓ TDD test setup
* ✓ implement basic/brute force prime number
* ✓ throw in faster Sieve of Eratosthenes implementation?