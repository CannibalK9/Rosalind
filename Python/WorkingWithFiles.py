data = open("C:\code\dataset.txt").read().splitlines()

for idx, d in enumerate(data):
    if idx % 2 == 1:
        print d

print ''.join(open("C:\code\dataset.txt").readlines()[1::2])
