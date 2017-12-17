# optimus-prime

A little prime number factoring app.

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
* setup coverage tool and script to run it
* tdd test setup
* implement basic/brute force prime number
* throw in faster Sieve of Eratosthenes implementation?