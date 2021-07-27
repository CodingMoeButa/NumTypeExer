#!/usr/bin/python3
import random
import time

print("贴贴我的百花酱！数字打字练习\n")
print("程序会随机生成若干组0至99999999的整数，每输入一组按回车键继续；要结束练习，请输入-1并回车。")
print("练习结束后会显示所用时间、完成数目和输入速度，并列出输入错误的数字。\n")
input("按回车键开始：")

wrongList = []
sum = 0
start_time = time.time()
while True:
    target = random.randint(0, 99999999)
    print(str(target)+": ", end='')
    answer = int(input())
    if answer == -1:
        break
    sum += 1
    if target != answer:
        wrongNum = (target, answer)
        wrongList.append(wrongNum)
end_time = time.time()

print("\n错误列表：")
print("正确答案\t你的输入")
for wrongNum in wrongList:
    print(str(wrongNum[0]) + "\t" + str(wrongNum[1]))
used_time = end_time - start_time
print("\n练习" + str(sum) + "个，错误" + str(len(wrongList)) + "个，用时" + str(int(used_time)) + "秒，有效平均速度为每分钟" + str(format(float((sum-len(wrongList))/(used_time/60)), '.1f')) + "个。\n")

print("加油呀，爱你喔~\n")
input("按回车键退出……")