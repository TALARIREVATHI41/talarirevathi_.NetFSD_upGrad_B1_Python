function loadProgress(){

// Get completed courses
const completed = JSON.parse(localStorage.getItem("completedCourses")) || [];

// Total courses
const totalCourses = 6;

// Loop through all courses
for(let i = 1; i <= totalCourses; i++){

const progressBar = document.getElementById(`progress-${i}`);

if(completed.includes(i)){
progressBar.value = 100; // completed
}
else{
progressBar.value = 0; // not completed
}

}
// ✅ Total progress calculation
const totalProgress = document.getElementById("totalProgress");

if(totalProgress){
const percentage = (completed.length / totalCourses) * 100;
totalProgress.value = percentage;
}

}

loadProgress();