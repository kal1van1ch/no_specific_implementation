document.addEventListener('DOMContentLoaded', function () {
    //Номер 1
    let number1_button = document.getElementById('number1_button');
    number1_button.addEventListener('click', function (){
        let counter = document.getElementById('number1_counter');
        counter.textContent = String(Number(counter.textContent) + 1);
    });

    //Номер 2
    let number2_button = document.getElementById('number2_button');
    number2_button.addEventListener('click', function (){
        const name = document.getElementById('number2_input').value.trim();
        console.log(`Привет, ${name}!`)
    });

    //Номер 3
    let pushed = document.querySelector('input[name="theme"]:checked');
    let body = document.querySelector('body');
    if(!pushed){
        body.classList.add('light-theme');
    }

    document.querySelectorAll('input[name="theme"]').forEach(element => {
        element.addEventListener('click', function (){
            if(this.value === 'light'){
                body.classList.remove('dark-theme');
                body.classList.add('light-theme');
            }
            else{
                body.classList.add('dark-theme');
                body.classList.remove('light-theme');
            }
        })
    });

    //Номер 4
    let number4_button = document.getElementById('number4_button');
    number4_button.addEventListener('click', function (){
        let lst = document.getElementById('TOOD-list-list');

        let newTask = document.getElementById('TODO-list');
        let newElem = document.createElement('li');
        newElem.textContent = newTask.value;

        lst.appendChild(newElem);

        newTask.value = '';
    });

    //Номер 5
    let plus = document.getElementById('number5_button_plus');
    let minus = document.getElementById('number5_button_minus');
    let square = document.getElementById('number5_square');
    const INCR = 10;

    plus.addEventListener('click', function (){
        let currentSizeWidth = parseInt(square.style.width);
        let currentSizeHeight = parseInt(square.style.height);

        let newWidth = currentSizeWidth + INCR;
        let newHeight = currentSizeHeight + INCR;

        square.style.width = String(newWidth) + 'px';
        square.style.height = String(newHeight) + 'px';
    });

    minus.addEventListener('click', function (){
        let currentSizeWidth = parseInt(square.style.width);
        let currentSizeHeight = parseInt(square.style.height);

        let newWidth = currentSizeWidth - INCR;
        let newHeight = currentSizeHeight - INCR;

        square.style.width = String(newWidth) + 'px';
        square.style.height = String(newHeight) + 'px';
    });
});

