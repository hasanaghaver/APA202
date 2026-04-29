// 1.Verilmis arrayde tekrarlanan reqemleri silmek ve tekrar reqemlerin sayini gostermek.
// function frequency(arr) {
//     let newArr = [];
//     let count = 0;
//     for (let i = 0; i < arr.length; i++) {
//         let bool = false;
//         for (let j = 0; j < newArr.length; j++) {
//             if (arr[i] == newArr[j]) {
//                 bool = true;
//                 break;
//             }
//         }
//         if (bool) {
//             count++;
//         } else {
//             newArr.push(arr[i]);
//         }
//     }
//     console.log(newArr);
//     return count;
// }
// console.log(frequency([1,2,3,4,5,1,2,3]));


// 2.Verilmis sozun polindrom olub olmadığını yoxlayan alqoritm yazmaq.
// function palindrom(str) {
//     str = str.toLowerCase();
//     let newStr = "";
//     for (let i = str.length-1; i >= 0; i--) {
//         newStr +=str[i];
//     }
//     return newStr === str;
// }
// console.log(palindrom("Ada"));


// 3.Girilen ededin verilmis arreyde nece elementden kicik oldugunu yazan alqoritim.
// function smallNum(arr, num) {
//     let count = 0;
//     for (let i = 0; i < arr.length; i++) {
//         if (arr[i] < num) {
//             count++;
//         }
//     }
//     return count;
// }
// console.log(smallNum([1,2,1,3,4,5], 3));


// 4.Daxil edilen ededin Aboundant ve ya Deficient oldugunu yoxlayan 
// algorithm.(Abundant ədəd öz müsbət bolenlerinin(ozunden basqa) cəmi özündən
//  böyük olan müsbət tam ədədlərə deyilir. Eks halda Deficient eded olur.
//  12-Aboundant, 13- Deficient)
// function aboundantOrDeficient(num) {
//     let sum = 0;
//     for (let i = 1; i < num; i++) {
//         if (num % i == 0) {
//             sum+= i;
//         }
//     }
//     if (sum > num) {
//         return "Aboundant";
//     } else {
//         return "Deficient";
//     }   
// }
// console.log(aboundantOrDeficient(12));



// 5.Array-in bütün elementlərini kvadrata yüksəldib yeni array qaytaran funksiya yazın.
// function square(arr) {
//     let newArr = [];
//     for (let i = 0; i < arr.length; i++) {   
//         newArr.push(arr[i] * arr[i]);
//     }
//     return newArr;
// }
// console.log(square([1,2,3,4,5]));