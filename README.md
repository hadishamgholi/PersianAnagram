# PersianAnagram
find anagram of given persian word with simple GUI
### Requirements
this project is based on [Mono](https://www.mono-project.com/) (a Cross platform, open source .NET framework).
* download and install it from [here](https://www.mono-project.com/download/stable/) (it's better to install mono-complete)
* Jetbrains Rider is the IDE that this project is built on.

### Resourse
the idea of using prime numbers is gotten from a [quora](https://www.quora.com/What-is-the-shortest-algorithm-to-test-if-two-strings-are-anagrams) question and answer. <br/>
here is the summery of the idea (copied from quora): <br/>

Assign a prime number to each letter in the alphabet. Encode the letters in two words using the assignment. <br/>

Multiply the encoded words. Each anagram should have a unique result due to "Fundamental Theorem of Arithmetic". If results of two multiplications match, you have found your anagram. <br/>

Example :<br/>
Let's have two words in our alphabet and let's make the following assignment. <br/>
a -> 2 <br/>
b -> 3 <br/>
 
aba -> encode -> 232 -> multiply -> 12 <br/>
baa -> encode -> 322 -> multiply -> 12 <br/>
Anagrams! <br/>

