#http://rosalind.info/problems/afrq/
import math

data = map(float, open('C:\code\dataset.txt').read().split())
p = map(lambda a: str(math.sqrt(a) * (1 - math.sqrt(a)) * 2 + a), data)

print " ".join(p)
