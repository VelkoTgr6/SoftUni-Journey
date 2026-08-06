function validate() {
    document.getElementById('email').addEventListener('change', onChange);

    function onChange(e) {
        const element = e.currentTarget;
        let pattern = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

        if (!pattern.test(element.value)) {
            element.classList.add('error');
        } else {
            element.classList.remove('error');
        }
    }
}