// =================== QUIZ QUESTIONS ===================
const quizData = [

{
question: "Which language runs in browser?",
options: ["Java", "C", "JavaScript", "Python"],
answer: "JavaScript"
},

{
question: "Which tag is semantic?",
options: ["div", "section", "span", "b"],
answer: "section"
},

{
question: "Which is styling language?",
options: ["HTML", "CSS", "SQL", "XML"],
answer: "CSS"
},

// JavaScript
{
question: "Which keyword is used to declare a variable in JavaScript?",
options: ["var", "int", "string", "float"],
answer: "var"
},

{
question: "Which method is used to print in console?",
options: ["print()", "console.log()", "echo()", "write()"],
answer: "console.log()"
},

// HTML
{
question: "Which tag is used for inserting an image?",
options: ["img", "image", "src", "pic"],
answer: "img"
},

{
question: "Which tag is used for a hyperlink?",
options: ["link", "a", "href", "url"],
answer: "a"
},

// CSS
{
question: "Which property is used to change text color?",
options: ["font-color", "text-color", "color", "background"],
answer: "color"
},

{
question: "Which layout is used for flexible design?",
options: ["table", "flexbox", "inline", "block"],
answer: "flexbox"
},

// React
{
question: "React is mainly used for?",
options: ["Database", "UI", "Networking", "Security"],
answer: "UI"
},

{
question: "What is used to pass data in React?",
options: ["state", "props", "setState", "hooks"],
answer: "props"
},

// Bootstrap
{
question: "Bootstrap is used for?",
options: ["Backend", "Styling", "Database", "Server"],
answer: "Styling"
},

{
question: "Bootstrap grid system is based on how many columns?",
options: ["10", "12", "16", "8"],
answer: "12"
},

// Java
{
question: "Java is which type of language?",
options: ["Procedural", "Object-Oriented", "Markup", "Styling"],
answer: "Object-Oriented"
},

{
question: "Which keyword is used to create a class in Java?",
options: ["function", "class", "define", "object"],
answer: "class"
}

];


// =================== HANDLE CHANGE (onchange event) ===================
function handleChange(){
console.log("Option selected");

// Optional UX improvement: remove error message when user selects
const errorMsg = document.getElementById("errorMsg");
if(errorMsg){
errorMsg.innerText = "";
}
}


// =================== PROMISE FUNCTION ===================
function loadWithPromise(){
return new Promise(resolve => {
setTimeout(() => resolve("Loaded"), 1000);
});
}


// =================== LOAD QUIZ (ASYNC) ===================
async function loadQuiz(){

const container = document.getElementById("quizContainer");

// Loading message
container.innerHTML = "<p>Loading quiz...</p>";

// Simulate delay using Promise
await loadWithPromise();

// Clear loading
container.innerHTML = "";

// Render questions
quizData.forEach((q,index)=>{

const div = document.createElement("div");

div.innerHTML = `
<p>${index+1}. ${q.question}</p>

${q.options.map(option => `
<label>
<input type="radio" name="q${index}" value="${option}" onchange="handleChange()">
${option}
</label><br>
`).join("")}
`;

container.appendChild(div);

});

}

// Call function
loadQuiz();


// =================== SUBMIT QUIZ ===================
function submitQuiz(){

let score = 0;
let unanswered = 0;

const errorMsg = document.getElementById("errorMsg");

quizData.forEach((q,index)=>{

const answer = document.querySelector(
`input[name="q${index}"]:checked`
);

// Check unanswered
if(!answer){
unanswered++;
}
else if(answer.value === q.answer){
score++;
}

});

// Show error if unanswered
if(unanswered > 0){
errorMsg.innerText = "⚠ Please answer all questions before submitting!";
return;
}

// Clear error
errorMsg.innerText = "";

// Calculate results
const percentage = calculatePercentage(score,quizData.length);
const grade = calculateGrade(percentage);
const result = checkPassFail(percentage);
const message = feedbackMessage(grade);

// Display result
document.getElementById("result").innerHTML = `
<h3>Result</h3>
Score: ${score} / ${quizData.length}<br>
Percentage: ${percentage}%<br>
Grade: ${grade}<br>
Status: ${result}<br>
${message}
`;

// Save score
saveQuizScore(score);

}