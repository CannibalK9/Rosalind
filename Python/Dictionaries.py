data = open("C:\code\dataset.txt").read().split()

words = {}

for d in data:
    words[d] = data.count(d)

for w, v in words.items():
    print w + ' ' + str(v)

print('\n'.join(word + ' ' + str(data.count(word)) for word in set(data)))
