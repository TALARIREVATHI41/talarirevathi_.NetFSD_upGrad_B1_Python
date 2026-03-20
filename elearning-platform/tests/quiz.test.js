

const {
  calculatePercentage,
  calculateGrade,
  checkPassFail
} = require("../js/app");


// Test 1: Grade
test("Grade calculation", () => {
  expect(calculateGrade(90)).toBe("A");
});


// Test 2: Percentage
test("Percentage calculation", () => {
  expect(calculatePercentage(3,5)).toBe(60);
});


// Test 3: Pass/Fail
test("Pass fail", () => {
  expect(checkPassFail(40)).toBe("Fail");
});