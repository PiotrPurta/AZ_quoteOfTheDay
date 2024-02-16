Quote of the Day 

version: 0.1
author: Piotr Purta
e-mail: piotr.purta@gmail.com

The aim of this little project is to create Azure Function that will shuffle a new quote from table every 24hrs and store it in the file

Changelog:
0.1 - introduced a simple mechanism that returns a random quote (from the collection of two harcoded elements).
1.0 - added Azure Function that shuffles the quotes everyday. 

To display it on a webpage use the following JS code:

`<span id="quote"></span>
`<br/>
`<span id="author"></span>

`<script>
fetch('[url to blob]/todayQuote.txt')
  .then(response => response.json())
  .then(data => {
document.getElementById('quote').innerHTML = data.RowKey;
document.getElementById('author').innerHTML = data.Author;
});
`</script></div>