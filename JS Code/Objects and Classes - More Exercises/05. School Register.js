function solve(input) {
    let register = {};

    input.forEach(student => {
        const regex = /Student name: (\w+), Grade: (\d+), Graduated with an average score: (\d+(\.\d+)?)\b/;
        const match = student.match(regex);

        if (match) {
            const studentName = match[1];
            const currentGrade = parseInt(match[2], 10);
            const averageScore = parseFloat(match[3]);

            if (averageScore >= 3) {
                let nextGrade=currentGrade+1
                if (!register[nextGrade]) {
                    register[nextGrade] = [];
                }

                register[nextGrade].push({studentName, averageScore });
            }
        }
    });
    for (const grade in register) {
        score=0;
        count=0;
        console.log(`${grade} Grade`);
        console.log(`List of students: ${register[grade].map(student => student.studentName).join(', ')}`);
        register[grade].forEach(student => {
           score += student.averageScore;
           count++;
        });
        score/=count
        console.log(`Average annual score from last year: ${score.toFixed(2)}`);
        console.log(` `)
    }
}
solve(
    [
        'Student name: George, Grade: 5, Graduated with an average score: 2.75',
        'Student name: Alex, Grade: 9, Graduated with an average score: 3.66',
        'Student name: Peter, Grade: 8, Graduated with an average score: 2.83',
        'Student name: Boby, Grade: 5, Graduated with an average score: 4.20',
        'Student name: John, Grade: 9, Graduated with an average score: 2.90',
        'Student name: Steven, Grade: 2, Graduated with an average score: 4.90',
        'Student name: Darsy, Grade: 1, Graduated with an average score: 5.15'
        ]
        
)