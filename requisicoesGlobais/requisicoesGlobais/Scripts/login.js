const btnCadastro = document.querySelector('#btnAbrirCadastro');
const btnLogin = document.querySelector('#btnAbrirLogin');

btnCadastro.addEventListener('click', () => {
  document.querySelector('.login').style.display = 'none';
  document.querySelector('.cadastro').style.display = 'block';
});

btnLogin.addEventListener('click', () => {
  document.querySelector('.cadastro').style.display = 'none';
  document.querySelector('.login').style.display = 'block';
});
