const sorter = require('./sorter');

test('empty array', () => {
    const callback = jest.fn(() => {});
    let array = [];
    sorter(array, callback);

    expect(array).toEqual([]);
});

test('array with one element', () => {
    const callback = jest.fn(() => {});
    let array = [1];
    sorter(array, callback);

    expect(array).toEqual([1]);
});

test('array with multiple elements', () => {
    const callback = jest.fn(() => {});
    let array = [3,4,1,5,0,2,8];
    sorter(array, callback);

    expect(array).toEqual([0,1,2,3,4,5,8]);
});

test('callback called n times', () => {
    const callback = jest.fn(() => {});
    let array = [0, 1];
    sorter(array, callback);

    expect(callback).toHaveBeenCalledTimes(2);
})