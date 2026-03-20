// ================= PROFILE DATA =================

// Get quiz score
const score = localStorage.getItem("quizScore");

document.getElementById("score").innerText =
"Last Quiz Score: " + (score ? score : "No quiz taken");


// ================= COMPLETED COURSES =================

// Get completed courses
const completed = JSON.parse(localStorage.getItem("completedCourses")) || [];

const list = document.getElementById("completedList");

// If no courses completed
if(completed.length === 0){
const li = document.createElement("li");
li.innerText = "No courses completed yet";
list.appendChild(li);
}

// Display completed courses
completed.forEach(id => {

const li = document.createElement("li");
li.innerText = "Course ID: " + id;

list.appendChild(li);

});