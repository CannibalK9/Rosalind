data = open('C:\code\dataset.txt').read().split()
print int(data[0])**2 + int(data[1])**2
print sum(map(lambda a: int(a)**2, data))
