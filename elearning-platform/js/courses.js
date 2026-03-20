// courses.js

const courses = [

{
id:1,
title:"JavaScript",
description:"Learn the fundamentals of JavaScript programming.",
lessons:["Variables","Functions","Promises"]
},

{
id:2,
title:"HTML",
description:"Build structured webpages using HTML.",
lessons:["Tags","Forms","Semantic Elements"]
},

{
id:3,
title:"CSS",
description:"Style webpages with modern CSS techniques.",
lessons:["Selectors","Flexbox","Grid"]
},

{
id:4,
title:"React",
description:"Build dynamic UI using React.",
lessons:["Components","State","Props"]
},

{
id:5,
title:"Bootstrap",
description:"Design responsive pages using Bootstrap.",
lessons:["Grid","Components","Utilities"]
},

{
id:6,
title:"Java",
description:"Learn object-oriented programming in Java.",
lessons:["OOP","Collections","Exception Handling"]
}

];

function displayCourses(){

const container = document.getElementById("courseContainer");

let table = `
<table class="table table-bordered table-striped">
<thead class="table-dark">
<tr>
<th>ID</th>
<th>Course Name</th>
<th>Description</th>
<th>Lessons</th>
<th>Action</th>
</tr>
</thead>
<tbody>
`;

courses.forEach(course => {

table += `
<tr>
<td>${course.id}</td>
<td>${course.title}</td>
<td>${course.description}</td>
<td>
<ol>
${course.lessons.map(l => `<li>${l}</li>`).join("")}
</ol>
</td>
<td>
<button class="btn btn-success" onclick="completeCourse(${course.id})">
Complete
</button>
</td>
</tr>
`;

});

table += `</tbody></table>`;

container.innerHTML = table;

}

function completeCourse(id){

let completed = JSON.parse(localStorage.getItem("completedCourses")) || [];

if(!completed.includes(id)){
completed.push(id);
}

localStorage.setItem("completedCourses", JSON.stringify(completed));

alert("Course Completed!");

}

displayCourses();