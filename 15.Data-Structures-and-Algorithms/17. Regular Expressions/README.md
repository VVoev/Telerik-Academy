<!-- section start -->
<!-- attr: { class:'slide-title', hasScriptWrapper: true, showInPresentation:true, style:'' } -->
# Regular Expressions in <span>C#</span>
##  Fast ways to search and replace string

<div class="signature">
    <p class="signature-course">Data Structures and Algorithms</p>
    <p class="signature-initiative">Telerik Software Academy</p>
    <a href="https://telerikacademy.com" class="signature-link">https://telerikacademy.com</a>
</div>

<!-- section start -->
<!-- attr: { showInPresentation:true, style:'' } -->
# Table of Contents
- [Regular Expression Overview](#regex-overview)
- [Special Characters for beginning and end](#begin-end)
- [Special Characters in Regex](#other)

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
<!-- # Regular Expressions
##  Overview -->

<!-- attr: { id:'regex-overview', showInPresentation:true, style:'' } -->
# <a id="regex-overview"></a>Regular Expressions Overview
- A regular expression is a set of patterns used to match character combinations in strings
  - Find and extract data from a document
  - Validate content supplied in a form before it is submitted like:
    - Telephone numbers
    - SSN/EGN
    - Email addresses
    - Anything that follows a pattern

<!-- attr: { showInPresentation:true, style:'' } -->
# Regex Syntax
- Regular expressions are an extremely powerful tool implemented in most languages
- Yet, regular expressions have their own syntax and usage of special characters
  - Difficult to remember if you use them infrequently
- Regular expressions can be tested at:
  - http://www.regexr.com/

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
<!-- # Regex Special Characters for Beginning and End
##  `^` and `$` -->

<!-- attr: { id:'begin-end', showInPresentation:true, style:'' } -->
# <a id="begin-end"></a>Regex Special Characters for Beginning and End
- Special Characters:
  - `^` - matches the beginning of input
    - `^T`
      - Matches: 'Telerik Academy', 'Telerik', 'Theta'
      - Does not match: 'Academy', 'Good Telerik'
  - `$` - matches the end of input
    - `y$`
      - Matches: 'Telerik Academy', 'Academy', 'yummy'
      - Does not match: 'Telerik', 'Good Telerik'

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Regex Special Characters for Beginning and End
##  [Demo]() -->

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, style:'' } -->
<!-- # Special Characters in Regular Expressions
##  For matching all kinds of stuff -->

<!-- attr: { id:'other', hasScriptWrapper:true, showInPresentation:true, style:'' } -->
# <a id="other"></a>Special Characters in Regex
- The regular expressions have a set of special characters, <br>that have a different behavior
  - Characters for matching multiple characters
  - Characters for matching whitespace
  - Characters for matching digits
  - Characters for matching letters
  - Etc…
- Full list of special characters can be found at:
  - https://developer.mozilla.org/en/docs/Web/JavaScript/Guide/Regular_Expressions#Using_special_characters

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: `*`
- Special Characters in Regex:
  - `*` – The preceding character is matched 0 or more times
    - `a*`
      - Matches: alaaaaaa bala'
      - Does not match: 'Good Telerik', 'Doncho Minkov'
      - Remark: `Da*oncho`
        - Matches: 'Doncho Minkov'
        - 'a' is matched 0 times

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: *
##  [Demo]() -->

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: `+`
- Special Characters in Regex:
  - `+` – The preceding character is matched 1 or more times
    - `a+`
      - Matches: 'alaaaaaa bala'
      - Does not match: 'Doncho Minkov', 'Good Telerik'
    - Remark:
      - Does not match: 'Doncho Minkov'
- a+
- Da+oncho

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: +
##  [Demo]() -->

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: `?`
- Special Characters in Regex:
  - `?` – The preceding character is matched 0 or 1 times
    - `T?`
      - Matches: 'Telerik is Telerik'
      - Does not match: 'Academy'

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: ?
##  [Demo]() -->

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: `.` (dot)
- Special Characters in Regex:
  - .(dot) – matches any single character except the newline character
    - `.`
    - Matches: 'Telerik is Telerik'
    - Remark:
      - `.*`
      - Matches any whole string

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: . (dot)
##  [Demo]() -->

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: `|`
- Special Characters in Regex:
  - `|` – Matches one pattern or the other
  - T|A
    - Matches: '**T**elerik **A**cademy'

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: |
##  [Demo]() -->

<!-- attr: { showInPresentation:true, style:'font-size:45px' } -->
# Special Characters in Regex: `[ ]`
- Special Characters in Regex:
  - `[xyz]` – Character set
    - Matches any one of the enclosed characters
    - `[TAy]`
      - Matches: '**T**elerik **A**cadem**y**'

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: [ ]
##  [Demo]() -->

<!-- attr: { showInPresentation:true, style:'font-size:40px' } -->
# Special Characters in Regex: `[ ]`
- Special Characters in Regex:
  - `[x-z]` – Character set
      - Matches any one between the characters range
  - `[A-Z]`
    - Matches: '**T**elerik **A**cademy'
  - `[A-z]`
    - Matches: '**Telerik** **Academy**'
  - `[a-q]`
    - Matches: 'T**ele**r**ik** **Academ**y'
  - `[0-9]`
    - Matches: 'John in **19**-years-old'

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: [ ] Range
##  [Demo]() -->

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: `[^xyx]`
- Special Characters in Regex:
  - `[^xyx]` – A negated or complemented character set
    - Matches anything that is not enclosed in the brackets
    - `[^ea]+`
      - Matches: '**T**e**l**e**rik Ac**a**d**e**my**'
      - Does not match: 'eaaaaeeeaaa', 'aaaa', 'eeee'

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: [^xyz]
##  [Demo]() -->

<!-- attr: { showInPresentation:true, style:'' } -->
# Special Characters in Regex: `{}`
- Special Characters in Regex:
  - `{N}` – matches exactly `N` occurrences
    - Where `N` is a positive number
    - [A-z]{5}
      - Matches: '**Teler**ik **Acade**my', '**Donch**o **Minko**v'
      - Does not match: 'JS is the best'
  - `{N, M}` – matches at least `N` and at most `M` occurrences of the preceding character
    - Where `N` and `M` are positive integers
    - [A-z]{4, 5}
      - Matches: '**Teler**ik **Acade**my', 'JS is **best**'
      - Does not match: 'Ivo is the MAN'

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Special Characters: {}
##  [Demo]() -->

<!-- attr: { showInPresentation:true, style:'font-size:40px' } -->
# Other Special Characters in Regex
- Special Characters in Regex:
  - `\s` – matches a single white space character, including space, tab, form feed, line feed
  - `\S `– matches a single character other than white space
  - `\d` – matches a digit character
    - Equivalent to `[0-9]`
  - `\D` – matches any non-digit character
    - Equivalent to `[^0-9]`
  - `\w` – matches any alphanumeric character including the underscore
  - `\W` – matches any non-alphanumeric or underscore character

<!-- attr: { class:'slide-section demo', showInPresentation:true, style:'' } -->
<!-- # Other Special Characters in Regular Expressions
##  [Demo]() -->

<!-- section start -->
<!-- attr: { class: "slide-questions", hasScriptWrapper:true, showInPresentation:true, style:'' } -->
<!-- # Regular Expressions in <span>C#</span>
##  Questions -->

<!-- attr: { showInPresentation:true, hasScriptWrapper:true } -->
# Free Trainings @ Telerik Academy
- C# Programming @ Telerik Academy
    - [Data Structures and Algorithms](http://academy.telerik.com/student-courses/programming/data-structures-algorithms/about)
  - Telerik Software Academy
    - [telerikacademy.com](https://telerikacademy.com)
  - Telerik Academy @ Facebook
    - [facebook.com/TelerikAcademy](facebook.com/TelerikAcademy)
  - Telerik Software Academy Forums
    - [forums.academy.telerik.com](forums.academy.telerik.com)
