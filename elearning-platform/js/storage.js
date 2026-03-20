// storage.js


// Save quiz score
function saveQuizScore(score){

localStorage.setItem("quizScore", score);

}


// Get quiz score
function getQuizScore(){

return localStorage.getItem("quizScore");

}


// Save completed courses
function saveCompletedCourses(data){

localStorage.setItem("completedCourses",
JSON.stringify(data));

}


// Get completed courses
function getCompletedCourses(){

return JSON.parse(
localStorage.getItem("completedCourses")
);

}