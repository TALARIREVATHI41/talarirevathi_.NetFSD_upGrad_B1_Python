// app.js


// Calculate Percentage
function calculatePercentage(score,total){

return (score/total)*100;

}


// Calculate Grade
function calculateGrade(percentage){

if(percentage >= 80){
return "A";
}

else if(percentage >= 50){
return "B";
}

else{
return "C";
}

}


// Pass / Fail
function checkPassFail(percentage){

if(percentage >= 50){
return "Pass";
}

return "Fail";

}


// Feedback message using switch
function feedbackMessage(grade){

switch(grade){

case "A":
return "Excellent Performance!";

case "B":
return "Good Job!";

default:
return "Keep Practicing!";
}

}


// Export for Jest testing
if(typeof module !== "undefined"){

module.exports = {
calculatePercentage,
calculateGrade,
checkPassFail
};

}