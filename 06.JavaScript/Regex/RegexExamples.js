// literal syntax
const literalRegex = /y$/g;

// function constructor syntax
const constructorRegex = new RegExp('^T', 'g');

/*
Full list of properties and methods on MDN
RegExp.test – searches for a match in a given string. Returns true or false
RegExp.exec - searches for the next match in a given string
Returns an array of all captured groups for the found match or null.
    String.match – searches for a match in a string
Returns an array of information or null on a mismatch

String.replace – replaces the matched substring with a replacement substring
Returns the new string
String.split – breaks a string into an array of substrings, using a regex or a string search for matches
Returns an array
String.search – tests for a match in a string
It returns the index of the match, or -1 if the search fails
*/


//flags in Regex
// g-Global Search
//i-Case Insensitive search
//m multi line search
let academyRegex = /telerik\s(software\s|algo\s|kids\s)?academy/gi;

let text = 'George is studying JavaScript at Telerik Academy';
// true

// will contain array of matches substrings or null
let matches = text.match(academyRegex);

// get matches and matched groups one by one
let currentMatch;
while(currentMatch = academyRegex.exec(text)) {
    console.log(currentMatch);
}

text = 'text    with    lots of       spaces\n' +
    '      and lots of tabulations    ';
console.log(text.replace(/\s\s+/g, ' '));

/*
Split a JavaScript expression to get it's operands
String.split
*/

let expression = '4+5*count-initialCount+1';
let operands = expression.split(/\+|\*|-/);
console.log(operands);


text = 'JavaScript is awesome!';
let index = text.search(/is/);
console.log(index);

/*
Special Characters in Regex
Complete list of special characters can be found here

* – The preceding character/group is matched 0 or more times
+ – Almost the same behaviour as * - the preceding character/group is matched 1 or more times
    ? – The preceding character/group is matched 0 or 1 times
    .(dot) – matches any single character except the newline character

| – Matches one pattern or the other
    [xyz] – Character set - Matches any of the characters
    [x-z] – Character set - Matches any one between the characters range
    [^xyz] – Inverted characters set - Matches all other characters

{N} – matches exactly N occurrences of the preceding character/group
{N, M} – matches at least N and at most M occurrences of the preceding character/group
^ - matches the start of the string
$ matches the end of the string

\s – matches a single white space character, including space, tab, form feed, line feed
\S – matches a single character other than white space
\d – matches a digit character
Equivalent to [0-9]

\D – matches any non-digit character
Equivalent to [^0-9]
\w – matches any alphanumeric character including the underscore
\W – matches any non-alphanumeric or underscore character
*/

