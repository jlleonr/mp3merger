# MP3Merger
<br>
<h2> Small home project to merge two MP3 format files into a single file. </h2>
<hr>

<h3>Instructions: </h3> <br>

<p>
<ol>
  <li> Select two mp3 files using the UI buttons. </li>
  <li> Select the destination folder and file name for the merged audio file. </li>
  <li> Click on mix. </li>
</ol>
</p>

<hr>

<h3>Notes:</h3> <br>
<p>
This project started as a simple UI to test the merging algorithm. 
Later on, I implemented the merging feature as a web service in an ASP.Net web application and decided to transtion this 
WPF application into an MVVM architecture. There is still one event in the code-behind of the main view that
arguably breaks the MVVM pattern. I'm still working how to implement a command that takes the Window object
as argument to close the application after clicking the Exit button.
</p>
