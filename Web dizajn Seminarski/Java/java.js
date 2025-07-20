/*Slike*/ 
document.addEventListener('DOMContentLoaded', () => {
  const images = [
    'Slike/Pozadine/Bg-minato.png',
    'Slike/Pozadine/Bg-toranj.png',
    'Slike/Pozadine/Bg-gradA.png',
    'Slike/Pozadine/Bg-nebo.png',
    'Slike/Pozadine/Bg-ulica.png',
    'Slike/Pozadine/Bg-gradB.png',
  ];

  const intervalTime = 10000;
  let trenutniSlajdIndex = 0;
  let nextIndex = 1;

  const bg1 = document.getElementById('bg1');
  const bg2 = document.getElementById('bg2');

  bg1.style.backgroundImage = `url('${images[trenutniSlajdIndex]}')`;
  bg1.classList.add('visible');

  bg2.style.backgroundImage = `url('${images[nextIndex]}')`;

  function changeBackground() {
    if (bg1.classList.contains('visible')) {
      bg2.style.backgroundImage = `url('${images[nextIndex]}')`;
      bg2.classList.add('visible');
      bg1.classList.remove('visible');
    } else {
      bg1.style.backgroundImage = `url('${images[nextIndex]}')`;
      bg1.classList.add('visible');
      bg2.classList.remove('visible');
    }

    trenutniSlajdIndex = nextIndex;
    nextIndex = (nextIndex + 1) % images.length;
  }

  setInterval(changeBackground, intervalTime);
});

/*Tema strane*/

let tamniMod = localStorage.getItem('tamniMod');
const dugmeTeme = document.getElementById('Tema-dugme');

const ukljuciTamniMod = () => {
  document.body.classList.add('tamniMod');
  localStorage.setItem('tamniMod', 'aktivan');
};

const iskljuciTamniMod = () => {
  document.body.classList.remove('tamniMod');
  localStorage.setItem('tamniMod', null);
};

if (tamniMod === 'aktivan') ukljuciTamniMod();

dugmeTeme.addEventListener('click', () => {
  tamniMod = localStorage.getItem('tamniMod');
  tamniMod !== 'aktivan' ? ukljuciTamniMod() : iskljuciTamniMod();
});


/*Validacija Forme*/

function proveriFormu() {
  let ime = document.getElementById("ime").value.trim();
  let prezime = document.getElementById("prezime").value.trim();
  let email = document.getElementById("email").value.trim();
  let datum = document.getElementById("datum").value.trim();
  let poruka = document.getElementById("poruka").value.trim();
  let greska = document.getElementById("greska");

  if (!ime || !prezime || !email || !datum || !poruka) {
    greska.textContent = "Sva polja moraju biti ispunjena.";
    return false;
  }

  const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  if (!emailRegex.test(email)) {
    greska.textContent = "Unesite ispravan email.";
    return false;
  }

  const DanasnjiDan = new Date();
  const Rodjendan = new Date(datum);
  let Godina = DanasnjiDan.getFullYear() - Rodjendan.getFullYear();
  const monthDiff = DanasnjiDan.getMonth() - Rodjendan.getMonth();
  if (monthDiff < 0 || (monthDiff === 0 && DanasnjiDan.getDate() < Rodjendan.getDate())) {
    Godina--;
  }

  if (age < 18) {
    greska.textContent = "Morate biti stariji od 18 godina.";
    return false;
  }

  greska.textContent = "";
  alert("Poruka je uspešno poslata!");
  return true;
}

/*Slajder*/ 

let aktivniSlajd = 0;
const slajdovi = document.querySelectorAll(".Slajd");

let intervalAutomatskogSlajda;
let ResetovanjeTajmera;

function idiNaSlajd(noviIndex) {
  if (noviIndex === aktivniSlajd) return;

  slajdovi.forEach((slajd, i) => {
    slajd.classList.remove("trenutniSlajd", "naLevoSlajd", "naDesnoSlajd");
    if (i < noviIndex) slajd.classList.add("naLevoSlajd");
    else if (i > noviIndex) slajd.classList.add("naDesnoSlajd");
  });

  slajdovi[noviIndex].classList.add("trenutniSlajd");
  aktivniSlajd = noviIndex;
}

function promeniSlajd(pomeraj) {
  const noviIndex = (aktivniSlajd + pomeraj + slajdovi.length) % slajdovi.length;
  idiNaSlajd(noviIndex);
  resetujAutomatskiSlajd();
}

function automatskiPromeniSlajd() {
  const noviIndex = (aktivniSlajd + 1) % slajdovi.length;
  idiNaSlajd(noviIndex);
}

function resetujAutomatskiSlajd() {
  clearInterval(intervalAutomatskogSlajda);
  clearTimeout(ResetovanjeTajmera);
  ResetovanjeTajmera = setTimeout(pokreniAutomatskiSlajd, 30000);
}

function pokreniAutomatskiSlajd() {
  intervalAutomatskogSlajda = setInterval(automatskiPromeniSlajd, 20000);
}

document.addEventListener("DOMContentLoaded", () => {
  slajdovi.forEach((slajd, i) => {
    if (i === aktivniSlajd) slajd.classList.add("trenutniSlajd");
    else if (i < aktivniSlajd) slajd.classList.add("naLevoSlajd");
    else slajd.classList.add("naDesnoSlajd");
  });

  pokreniAutomatskiSlajd();
});
