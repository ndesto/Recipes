
var rIndex,
    table = document.getElementById('recipes');

function openFunction() {
    window.location = "https://localhost:7045/Recipes";
}

function addRecipe() {
    var newRow = table.insertRow(table.length),
        celI = newRow.insertCell(0),
        celN = newRow.insertCell(1),
        celD = newRow.insertCell(2),
        recNum = document.getElementById("recNum").value,
        recName = document.getElementById("recName").value,
        recDescr = document.getElementById("recDescr").value;

    celI.innerHTML = recNum;
    celN.innerHTML = recName;
    celD.innerHTML = recDescr;
}



function selectRecipe() {
    for (var i = 0; i < table.rows.length; i++) {
        table.rows[i].onclick = function () {
            rIndex = this.rowIndex;
            document.getElementById('recNum').value = this.cells[0].innerHTML;
            document.getElementById('recName').value = this.cells[1].innerHTML;
            document.getElementById('recDescr').value = this.cells[2].innerHTML;
        };
    }
}

selectRecipe();

function editRecipe() {
    var recNum = document.getElementById('recNum').value,
        recName = document.getElementById('recName').value,
        recDescr = document.getElementById('recDescr').value;
    table.rows[rIndex].cells[0].innerHTML = recNum;
    table.rows[rIndex].cells[1].innerHTML = recName;
    table.rows[rIndex].cells[2].innerHTML = recDescr;
}

function deleteRecipe() {
    table.deleteRow(rIndex);
}
