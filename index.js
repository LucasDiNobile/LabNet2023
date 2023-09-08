let numAleatorio = Math.floor(Math.random() * 20);
let enviar = document.querySelector('#enviar');
let reiniciar = document.querySelector('#reinicio');
let score = 20;
let num = document.querySelector("#num1");
let enviarBool = true;
let mainBool = true;
let highscore = [0,0,0,0,0];
let highscoreHTML = document.querySelector("#highscore");
let scoreHTML = document.querySelector("#tuScore");
let pista = document.querySelector("#pista");

enviar.addEventListener("click", function(a){ 
    a.preventDefault();
    const b = parseInt(num.value);
    if(isNaN(b)){
        Swal.fire(
            'No te he entendido',
            'Solo puedes ingresar numeros',
            'question'
          )
    }else{
        check(b);
        score0();
    }
    
})

reiniciar.addEventListener("click", function(){
    reinicio();
})

function reinicio(){
    Swal.fire({
        title: 'Estas seguro?',
        text: "Perdera todo el progreso de esta partida!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, reiniciar!'
      }).then((result) => {
        if (result.isConfirmed) {
            Swal.fire(
            'Listo!',
            'la partida se ha reiniciado.',
            'success'
            )
            score = 20;
            scoreHTML.innerHTML = score
            numAleatorio = Math.floor(Math.random() * 20);
        }
      })
}

function score0(){
    if(score == 0){  
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Has perdido, la partida se ha reiniciado!',
        })
        highscore.push(score);
        highscoreHTML.innerHTML = highscore;
        score = 20;
        scoreHTML.innerHTML = score
        numAleatorio = Math.floor(Math.random() * 20);
    }
}

function check(numero){

    if(numero > numAleatorio){
        pista.innerHTML = "Muy alto!, ingrese un numero mas bajo";
        score--
        scoreHTML.innerHTML = score;
        
    }else if(numero < numAleatorio){
        pista.innerHTML = "Muy bajo!, ingrese un numero mas alto";
        score--;
        scoreHTML.innerHTML = score;

    }else if(numero === numAleatorio){
        if(score > highscore[4]){
            highscore[4] = score;
            highscore.sort();
            highscore.reverse();
            highscoreHTML.innerHTML = highscore;   
        }
        score = 20;
        scoreHTML.innerHTML = score
        numAleatorio = Math.floor(Math.random() * 20);
        Swal.fire({
            title: 'Ganaste!',
            text: "La partida se reiniciará",
            icon: 'success',
            showCancelButton: false,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Ok'
        })
    }
}


