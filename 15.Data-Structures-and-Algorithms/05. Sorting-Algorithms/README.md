<!-- section start -->
<!-- attr: { class:'slide-title', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Sorting Algorithms
## QuickSort, MergeSort, etc...
<aside class="signature">
    <p class="signature-course">Data Structures and Algorithms</p>
    <p class="signature-initiative">Telerik Software Academy</p>
    <a href="https://telerikacademy.com" class="signature-link">https://telerikacademy.com</a>
</aside>

<!-- section start -->
<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Table of Contents
- [Sorting](#sortingAlgorithm)
  - [Sorting and classification](#classification)
- [Review of the most popular sorting algorithms](#selection)
  - [Selection sort](#selection)
  - [Bubble sort](#bubble)
  - [Insertion sort](#insertion)
  - [Quick sort](#quick)
  - [Merge sort](#merge)
  - [Heap sort](#heap)
  - [Counting sort](#counting)
  - [Bucket sort](#bucket)

<!-- section start -->
<!-- attr: { class:'slide-section', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
<!-- # What is a Sorting Algorithm? -->

<!-- attr: { id:'sortingAlgorithm', showInPresentation:true, hasScriptWrapper:true } -->
# <a id="sortingAlgorithm"></a>What is a Sorting Algorithm?

- Sorting algorithm
  - An algorithm that **puts elements** of a list in a **certain order** (most common lexicographically)
- More formally:
  - The output is **in some (non-decreasing) order**
  - The output is **a permutation** of the input
- Efficient sorting is important for
  - Producing human-readable output
  - Canonicalizing data
  - Optimizing the use of other algorithms
- Sorting presents many important techniques

<!-- attr: { id:'classification', showInPresentation:true, style:'' } -->
# <a id="classification"></a>Classification

- Sorting algorithms are often classified by
  - Computational **complexity**
    - **worst**, **average** and **best** behavior
  - **Memory** usage
  - Recursive or non-recursive
  - **Stability**
  - Whether or not they are a comparison sort
  - General method
    - insertion, exchange (bubble sort and quicksort), selection (heapsort), merging, serial or parallel…

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# Stability of Sorting

- Stable sorting algorithms <!-- .element: style="width:70%" -->
  - Maintain the relative order of records with equal values
- If two items compare as equal, then their relative order will be preserved
  - When sorting only part of the data is examined when determining the sort order

<img class="slide-image" src="imgs/stability.png" style="width:25%; top:15%; right:-20%" />

<!-- section start -->
<!-- attr: { class:'slide-section' } -->
<!-- # Selection sort -->

<!-- attr: { hasScriptWrapper:true } -->
<!-- attr: { id:'selection', showInPresentation:true, hasScriptWrapper:true, style:'font-size:42px' } -->
# <a id="selection"></a>Selection sort

- Very simple and very inefficient algorithm
  - Best, worst and average case: `n`<sup>`2`</sup>
  - Memory: `1` (constant, only for the min element)
  - Stable: No
  - Method: Selection

```cs
  for j = 0 ... n-2
      // find the best element in a[j .. n-1]
      best = j;
      for i = j + 1 ... n -1
          if a[i] < a[best]
            best = i;
      if best is not j
        swap a[j], a[best]
```

  - http://en.wikipedia.org/wiki/Selection_sort

<!-- attr: {class: 'slide-section'} -->
<!-- # Selection sort
##  [Demo](./demos) -->

<!-- section start -->
<!-- attr: { class:'slide-section' } -->
<!-- # Bubble sort -->

<!-- attr: { id:'bubble', showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.8em' } -->
# <a id="bubble"></a>Bubble sort

- Repeatedly stepping through the list
  - Comparing each pair of adjacent items
    - Swap them if they are in the wrong order
  - Best case: `n`, worst and average case: `n`<sup>`2`</sup>
  - Memory: `1`, Stable: Yes, Method: Exchanging

```cs
while swapIsDone
  swapIsDone = false
  for i = 0 ... n - 1
    if a[i-1] > a[i]
      swap a[i] a[i-i]
      swapIsDone = true
```

- http://en.wikipedia.org/wiki/Bubble_sort

<!-- attr: {class: 'slide-section'} -->
<!-- # Bubble sort
##  [Demo](./demos) -->


<!-- section start -->
<!-- attr: { class:'slide-section' } -->
<!-- # Insertion sort -->

<!-- attr: { id:'insertion', showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.9em' } -->
# <a id="insertion"></a>Insertion sort

- Builds the final sorted array one item at a time
  - Best case: `n`, worst and average case: `n`<sup>`2`</sup>
  - Memory: `1`, Stable: Yes, Method: Insertion

```cs
for i = 1 ... n - 1
  valueToInsert = a[i]
  holePos = i
  while holePos > 0 and valueToInsert < A[holePos - 1]
    a[holePos] = A[holePos - 1] // shift the larger value up
    holePos = holePos - 1       // move the hole position down
  A[holePos] = valueToInsert
```

- http://en.wikipedia.org/wiki/Insertion_sort


<!-- attr: { showInPresentation:true, class: 'slide-section'} -->
<!-- # Insertion sort
##  [Demo](./demos) -->

<!-- section start -->
<!-- attr: { class:'slide-section' } -->
<!-- # Quicksort -->

<!-- attr: { id:'quick', showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.75em'} -->
# <a id="quick"></a>Quicksort
- First divides a large list into two smaller sub-lists then recursively sort the sub-lists
  - Best and average case: `n*log(n)`, worst: `n`<sup>`2`</sup>
  - Memory: `log(n)` stack space
  - Stable: Depends
  - Method: Partitioning

```cs
function quicksort('array')
  if len('array') <= 1:
    return
  select and remove a pivot value from 'array'
  create empty lists 'less' and 'greater'
  for each 'x' in 'array':
    if 'x' <= 'pivot':
      append 'x' to 'less'
    else:
      append 'x' to greater
  return concatenate (quicksort('less'), 'pivot', quicksort('greater'))
```

  - http://en.wikipedia.org/wiki/Quicksort
<div class="fragments balloon" style="width:250px; top:50%; left:50%">Stable implementation</div>

<!-- attr: {showInPresentation:true, class: 'slide-section'} -->
<!-- # Quick sort
## [Demo](./demos) -->

<!-- section start -->
<!-- attr: { class:'slide-section' } -->
<!-- # Merge sort -->

<!-- attr: { id:'merge', showInPresentation:true, hasScriptWrapper:true, style:'font-size:0.8em' } -->
# <a id="merge"></a>Merge Sort
- Conceptually, a merge sort works as follows
  - Divide the unsorted list into `n` sublists, each containing `1` element (list of 1 element is sorted)
  - Repeatedly merge sublists to produce new sublists until there is only 1 sublist remaining
- Best, average and worst case: `n*log(n)`
- Memory: Depends; worst case is `n`
- Stable: Yes;
- Method: Merging
- Highly parallelizable (up to `O(log(n)`)
  - using the Three Hungarian's Algorithm
- http://en.wikipedia.org/wiki/Merge_sort

<img class="slide-image" src="imgs/mergesort.png" style="width:40%; top:35%; left:73%" />

<!-- attr: { showInPresentation:true, style:'font-size:0.9em' } -->
<!-- # Merge Sort -->
- Pseudocode

```cs
function merge_sort(list m)
    // if list size is 0 (empty) or 1, consider it sorted
    // (using less than or equal prevents infinite recursion
    // for a zero length m)
  if length(m) <= 1
      return m
    // else list size is > 1, so split the list into two sublists
  var list left, right
  var integer middle = length(m) / 2
  for each x in m before middle
       add x to left
  for each x in m after or equal middle
       add x to right
    // recursively call merge_sort() to further split each sublist
    // until sublist size is 1
  left = merge_sort(left)
  right = merge_sort(right)
    // merge the sublists returned from prior calls to merge_sort()
    // and return the resulting merged sublist
  return merge(left, right)
```

<!-- attr: { showInPresentation:true, hasScriptWrapper:true, style:'' } -->
<!-- # Merge Sort -->

```cs
function merge(left, right)
    var list result
    while length(left) > 0 or length(right) > 0
        if length(left) > 0 and length(right) > 0
            if first(left) <= first(right)
                append first(left) to result
                left = rest(left)
            else
                append first(right) to result
                right = rest(right)
        else if length(left) > 0
            append first(left) to result
            left = rest(left)
        else if length(right) > 0
            append first(right) to result
            right = rest(right)
    end while
    return result
```

<!-- attr: {showInPresentation:true, class: 'slide-section'} -->
<!-- # Merge sort
## [Demo](./demos) -->

<!-- section start -->
<!-- attr: { class:'slide-section' } -->
<!-- # Heap -->

<!-- attr: { id:'heap', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# <a id="heap"></a>Heap
- Specialized tree-based data structure that satisfies the heap property:
  - Parent nodes are always greater (less) than or equal to the children
    - No implied ordering between siblings or cousins

<img class="slide-image" src="imgs/heap.png" style="position:initial; width:60%; margin:-10px 0;" />
- https://en.wikipedia.org/wiki/Heap_data_structure
<img class="slide-image" src="imgs/heap-tree.png" style="width:30%; top:52%; left:67%" />

<!-- attr: { showInPresentation:true, style:'' } -->
<!-- # Heapsort -->
- Can be divided into two parts
  - In the first step, a heap is built out of the data
  - A sorted array is created by repeatedly removing the top element from the heap
- Best, average and worst case: `n*log(n)`
- Memory: Constant - `O(1)`
- Stable: No
- Method: Selection
- http://en.wikipedia.org/wiki/Heapsort

<!-- attr: {showInPresentation:true, class: 'slide-section'} -->
<!-- # Heap sort
##  [Demo](./demos) -->

<!-- section start -->
<!-- attr: { class:'slide-section' } -->
<!-- # Counting sort -->

<!-- attr: { id:'counting', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# <a id="counting"></a>Counting sort
- Algorithm for sorting a collection of objects according to keys that are small integers
  - Or big integers and a `map`
- Not a comparison sort
- Average case: `n + r`
- Worst case: `n + r`
  - `r` is the range of numbers to be sorted
- Stable: Yes
- Memory: `n + r`
- http://en.wikipedia.org/wiki/Counting_sort
<img class="slide-image" src="imgs/counting-sort.png" style="width:35%; top:27%; right:0%" />

<!-- attr: {showInPresentation:true, class: 'slide-section'} -->
<!-- # Counting sort
##  [Demo](./demos) -->


<!-- section start -->
<!-- attr: { class:'slide-section' } -->
<!-- # Bucket sort -->

<!-- attr: { id:'bucket', showInPresentation:true, hasScriptWrapper:true, style:'' } -->
# <a id="bucket"></a>Bucket sort
- Partitioning an array into a number of buckets
  - Each bucket is then sorted individually
- Not a comparison sort
- Average case: `n + k`
  - `k` = the number of buckets
- Worst case: `n2 * k`
- Stable: Yes
- Memory: `n * k`
- http://en.wikipedia.org/wiki/Bucket_sort

<img class="slide-image" src="imgs/bucket-sort.png" style="width:40%; top:26%; right:0" />

<!-- attr: {showInPresentation:true, class: 'slide-section'} -->
<!-- # Bucket sort
##  [Demo](./demos) -->

<!-- section start -->
<!-- attr: { class:'slide-section' } -->
<!-- # Comparison of Sorting Algorithms -->

<!-- attr: {hasScriptWrapper:true, showInPresentation:true, style:'font-size:40px' } -->
# Comparison of Sorting Algorithms
- There are hundreds of sorting algorithms
  - Some of them are:

| Name      | Best       | Avg           | Worst         | Memory | Stable  |
|:----------|:-----------|:--------------|:--------------|:-------|:--------|
| Bubble    | n          | n<sup>2</sup> | n<sup>2</sup> | 1      | Yes     |
| Insertion | n          | n<sup>2</sup> | n<sup>2</sup> | 1      | Yes     |
| Quick     | n\*log(n)  | n\*log(n)     | n<sup>2</sup> | log(n) | Depends |
| Merge     | n\*log(n)  | n\*log(n)     | n\*log(n)     | n      | Yes     |
| Heap      | n\*log(n)  | n\*log(n)     | n\*log(n)     | n      | No      |
| Bogo      | n          | n\*n!         | n\*n!         | 1      | No      |

<!-- section start -->
<!-- attr: { id:'questions', class:'slide-questions', showInPresentation:true, style:'' } -->
<!-- # Questions
## Sorting Algorithms -->

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
