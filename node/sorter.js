function sort(array, callback) {
    for(let i = 0; i < array.length; i++) {
        callback("" + (i+1) + " / " + array.length);
        for (let current = 0; current < array.length - 1; current++) {
           if (array[current] > array[current+1]) {
               const temp = array[current];
               array[current] = array[current+1];
               array[current+1] = temp;
           }
        }
    }
}

module.exports=sort;