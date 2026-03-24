document.addEventListener('DOMContentLoaded', () => {

    //Номер 1
    addUserButton = document.getElementById('addUserButton');
    addUserButton.addEventListener('click', () => {
       lst = document.querySelector('.list-of-users');

       newElem = document.createElement('li');
       newElem.textContent = 'Новый пользователь';

       lst.appendChild(newElem);
    });

    //Номер 2
    redElem = document.querySelector('.special');
    if(redElem) {
        redElem.classList.add('red-text');
    }

    lstOfText = document.querySelectorAll('.text');

    if(lstOfText) {
        for(let i = 0; i < lstOfText.length; i++) {
            if((i + 1) % 3 === 0){
                lstOfText[i].classList.add('green-background');
            }
        }
    }

    lst = document.querySelector('.text');
    parent = lst.parentNode;

    if(parent) {
        parent.classList.add('border');
    }

    //Номер 3
    itemElems = document.querySelectorAll('.item');

    itemElems.forEach(elem => {
        if(elem.classList.contains('active')) {
            elem.classList.add('highlight');
        }
    });

    let sum = 0;

    itemElems.forEach(elem => {
       sum += Number(elem.dataset.price);
    });

    const answer = document.createElement('div');
    answer.textContent = `Сумма: ${sum}`;

    const elem = document.querySelector('.number3');
    elem.appendChild(answer);

    let maxPrice = -1;
    let goodName;

    itemElems.forEach(elem => {
       const price = Number(elem.dataset.price);

       if(price > maxPrice) {
           maxPrice = price;
           goodName = elem.textContent;
       }
    });
    console.log(goodName);
});