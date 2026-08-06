function search() {
   let list=Array.from(document.getElementById('towns').children)
   let search=document.getElementById('searchText').value.toLowerCase()
   let matches=0;

   for (const word of list) {
      word.style.textDecoration = ''; 
      word.style.fontWeight = '';
   }

   for (const word of list) {
      let townName = word.textContent.toLowerCase()
     if (townName.includes(search)) {
      matches++
      word.style.textDecoration = 'underline'; 
      word.style.fontWeight = 'bold';
     } 
   }
   document.getElementById('result').textContent=`${matches} matches found`
}
