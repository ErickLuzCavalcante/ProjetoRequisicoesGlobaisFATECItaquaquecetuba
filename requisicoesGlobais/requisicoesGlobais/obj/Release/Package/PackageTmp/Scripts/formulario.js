function abrirFecharCampo() {
    const checkBox = document.querySelector('#checkBox');
    const tranqMat = document.querySelector('#tranqMat');
    if(checkBox.checked) {
        campoTrancamento.style.display = 'block';
    } else {
        campoTrancamento.style.display = 'none';
    }
    tranqMat.value = '';
}