data = open("C:\code\dataset.txt").read().split()

a = int(data[0])
b = int(data[1]) + 1

total = 0
for x in (y for y in range(a, b) if y % 2 == 1):
    total+=x
print total

print sum(y for y in range(a, b) if y % 2 == 1)

print sum(range(a|1, b, 2))
