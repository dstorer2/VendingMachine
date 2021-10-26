// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// page loading function
function load(event){
    event.preventDefault();
    var path = event.target.getAttribute("href")
    $.get(path, function(data){
        $("#app").html(data)
    });
}

// I should have made the "deposited total" an attribute of a class.
// building a function instead
function depositCoin(event){
    event.preventDefault();
    let total = parseInt(depositAmount.value)
    let coinVal = parseInt(event.target.value)
    total += coinVal;
    // just found out you can get an element by just declaring it's id ***mind blown***
    depositAmount.value = total;
    depositAmount.innerHTML = `$${depositAmount.value/100}`
}

function outOfStockAlert(){
    alert("This item is out of stock.")
}

// this function happens when you click one of the reference buttons on the interface (i.e. "B2")
// find "physical" candy using reference button id
// compare candy price to deposited amount
function buyCandy(event){
    event.preventDefault();
    // first thing is to compare the deposited money amount to the value of the selected candy
    let id = event.target.value;
    let candyElement = document.getElementById(id);
    let candyPrice = parseFloat(candyElement.innerHTML.replace("$", ""));
    console.log("candy price:", candyPrice)
    let depositedMoney = parseInt(depositAmount.value)/100;
    console.log("deposited money:", depositedMoney)
    // if not enough money, reset deposit amount to zero (as per assignment prompt (seems harsh)) and send alert
    if(candyPrice > depositedMoney){
        depositAmount.value = 0;
        depositAmount.innerHTML = "$0.00";
        alert("Insufficient Funds");
        return;
    }
    // redirect to the buy candy method
    let path = event.target.getAttribute("href")
    $.get(path, function(data){
        $("#app").html(data)
    });
}

// these functions are for the manage inventory page. Stock or unstock candy by clicking the - or + buttons. Arbitrary caps at 0 and 20
function removeCandy(event){
    event.preventDefault();
    let qty = parseInt(event.target.value);
    if(qty <= 0){
        alert("There's no candy to remove.")
        return;
    }
    let path = event.target.getAttribute("href")
    $.get(path, function(data){
        $("#app").html(data)
    });
}

function addCandy(event){
    event.preventDefault();
    let qty = parseInt(event.target.value);
    if(qty >= 20){
        alert("There's no more room in this slot")
        return;
    }
    let path = event.target.getAttribute("href")
    $.get(path, function(data){
        $("#app").html(data)
    });
}
