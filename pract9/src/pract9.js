function checkIfAge(numberForCheck){
    return (
        !Number.isNaN(numberForCheck) &&
        numberForCheck > 0 &&
        Number.isInteger(numberForCheck)
    );
}


function number1(){
    let userName;
    let userAge;

    while(true){
        userName = prompt('Назовите ваше имя');
        userAge = prompt('Введите ваш возраст');

        if(userName === null || userAge === null){
            alert('Параметры не введены');
            continue;
        }

        if(userName.trim() === '' || userAge.trim() === ''){
            alert('Параметры не введены');
            continue;
        }

        let numberForCheck = Number(userAge);

        if(checkIfAge(numberForCheck)){
            userAge = numberForCheck;
        }
        else{
            alert('Возраст введён некорректно')
            continue;
        }

        break;
    }

    let message = `Привет, ${userName}, тебе ${userAge} лет!`;
    alert(message);
    console.log(userAge);
    console.log(userName);
}


function number2(){
    let userAge;

    while(true){
        userAge = prompt('Введите ваш возраст');

        if(userAge === null){
            alert('Параметр не введён');
            continue;
        }

        if(userAge.trim() === ''){
            alert('Параметр не введён');
            continue;
        }

        let numberForCheck = Number(userAge);

        if(checkIfAge(numberForCheck)){
            userAge = numberForCheck;
        }
        else{
            alert('Возраст введён некорректно');
            continue;
        }

        break;
    }

    let access = 'Доступ разрешён';
    let deny = 'Доступ запрещён';

    if(userAge >= 18){
        alert(access);
    }
    else{
        alert(deny);
    }
}


function number3(){
    let randomNumber = Math.floor(Math.random() * 10) + 1;
    let userAnswer;
    let win = 'Ты угадал!';
    let endGame = 'Игра окончена 😈';
    let more = 'Загаданное число больше. Попробуй ещё раз';
    let less = 'Загаданное число меньше. Попробуй ещё раз';

    while(true){
        userAnswer = prompt('Угадайте число');
        let numberForCheck = Number(userAnswer);

        if(userAnswer === null){
            alert(endGame);
            break;
        }

        if(numberForCheck === randomNumber){
            alert(win);
            break;
        }

        else if(numberForCheck < randomNumber){
            alert(more);
        }

        else {
            alert(less)
        }
    }
}


function number4(){
    let password = '0000';
    let userPass;
    let noPass = 'Пароль не введён';
    let access = 'Доступ разрешён';
    let deny = 'Доступ запрещён';

    while(true){
        userPass = prompt('Введите пароль');
        if(userPass === null || userPass.trim() === ''){
            alert(noPass);
            continue;
        }

        switch(userPass){
            case password:
                alert(access);
                break;
            default:
                alert(deny);
                break;
        }
        break;
    }
}


function number5(){
    alert('Простой калькулятор. Принимает целые числа (1, 2, 12) и числа с плавающей запятой (1.5, 2.7 (В виде разделителя использовать точку))');
    let num1;
    let num2;
    let operation;
    const OPERATIONS = ['+', '-', '*', '/'];

    while(true){
        num1 = prompt('Введите число 1');
        if(num1 === null || num1.trim() === ''){
            alert('Число не введено');
            continue;
        }
        if(Number.isNaN(Number(num1))){
            alert('Это не число, либо число в формате 7,7 (с запятой вместо точки)');
            continue;
        }
        break;
    }

    while(true){
        num2 = prompt('Введите число 2');
        if(num2 === null || num2.trim() === ''){
            alert('Число не введено');
            continue;
        }
        if(Number.isNaN(Number(num2))){
            alert('Это не число, либо число в формате 7,7 (с запятой вместо точки)');
            continue;
        }
        break;
    }

    while(true){
        operation = prompt('Введите оператор из списка [+ - * /]');
        if(operation === null || operation.trim() === ''){
            alert('Оператор не введён');
            continue;
        }
        if(!OPERATIONS.includes(operation)){
            alert('Такого оператора нет, попробуй ещё раз');
            continue;
        }
        break;
    }

    num1 = Number(num1);
    num2 = Number(num2);

    switch(operation){
        case '+':
            alert(`Ответ ${num1 + num2}`);
            break;
        case '-':
            alert(`Ответ ${num1 - num2}`);
            break;
        case '*':
            alert(`Ответ ${num1 * num2}`);
            break;
        case '/':
            if(num2 === 0){
                alert('На ноль делить нельзя');
                break;
            }
            else{
                alert(`Ответ ${num1 / num2}`);
                break;
            }
    }
}


alert('Номер 1');
number1();
alert('Номер 2');
number2();
alert('Номер 3');
number3();
alert('Номер 4');
number4();
alert('Номер 5');
number5();