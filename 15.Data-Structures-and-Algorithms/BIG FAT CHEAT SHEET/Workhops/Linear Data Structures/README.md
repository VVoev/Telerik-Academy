# BucketList

Implement a linear data structure. It should support the following operations:

| Operation                 | Sample usage                     | Average case complexity | Best case complexity | Worst case complexity |
|:--------------------------|:---------------------------------|:------------------------|:---------------------|:----------------------|
| Get element at index      | `var x = list[index];`           | `O(1)`                  | `O(1)`               | `O(1)`                |
| Set element at index      | `list[index] = x;`               | `O(1)`                  | `O(1)`               | `O(1)`                |
| Append element at the end | `list.Add(x);`                   | `O(1)`                  | `O(1)`               | `O(n)`                |
| Insert element at index   | `list.Insert(index, x);`         | `O(√n)`                 | `O(1)`               | `O(n)`                |
| Remove element at index   | `list.Remove(index);`            | `O(√n)`                 | `O(1)`               | `O(n)`                |
| Traversing elements       | `foreach(var x in list) { ... }` | `O(n)`                  | `O(n)`               | `O(n)`                |

- _Notes:_
  - It is OK to use structures from the standard library (`e.g. List<T>`)
  - More than one approach may be possible
  - If you manage to write something better, good for you :)

- _Hints:_
  - Split your linear data structure into different parts (buckets)
	- How big should they be and how many?
  - Cyclic arrays may help
