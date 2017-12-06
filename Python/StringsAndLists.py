data = open("C:\code\dataset.txt")
text = data.readline()
slices = map(lambda a: int(a), data.readline().split())

print text[slices[0]:slices[1]+1] + " " + text[slices[2]:slices[3]+1]
