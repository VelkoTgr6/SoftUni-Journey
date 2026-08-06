function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   let tableRows = document.querySelectorAll('tbody tr')
   let search = document.getElementById('searchField')

   function onClick() {


      for (const row of tableRows) {
         row.classList.remove('select');
         if (search !== '' && row.innerHTML.includes(search.value)) {
            row.className = 'select';
         }
      }

      search.value = '';

   }
}